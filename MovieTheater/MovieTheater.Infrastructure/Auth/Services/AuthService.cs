using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieTheater.Domain.Entities;
using MovieTheater.Infrastructure.Auth.JWT;
using MovieTheater.Infrastructure.Auth.Models;
using MovieTheater.Infrastructure.Auth.Services.Interfaces;
using MovieTheater.Infrastructure.Exceptions.AuthException;

namespace MovieTheater.Infrastructure.Auth.Services;

public class AuthService: IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtHandler _jwtHandler;

    public AuthService(
        UserManager<User> userManager, 
        IMapper mapper, 
        SignInManager<User> signInManager,
        IJwtHandler jwtHandler)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _jwtHandler = jwtHandler;
    }

    public async Task<User> SignupUser(UserSignupModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            throw new PasswordsDontMatchException(model.Password, model.ConfirmPassword);
        }
        
        var user = _mapper.Map<User>(model);

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new SignupFailedException("Duplicate user name or email");
        }

        await _userManager.AddToRoleAsync(user, "Visitor");
        return user;
    }

    public async Task<JwtResponse> Login(UserLoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            throw new UserWithGivenEmailWasNotFoundException(model.Email);
        }

        var result = await _signInManager
            .PasswordSignInAsync(user, model.Password, model.RememberMe, false);

        if (!result.Succeeded)
        {
            throw new InvalidCredentialException("Invalid email or password");
        }

        var claims = await _jwtHandler.GetClaimsAsync(user);
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var token = _jwtHandler.GenerateToken(signingCredentials, claims);

        return new JwtResponse()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ValidTo = token.ValidTo
        };
    }
}