using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Infrastructure.Auth.Models;
using MovieTheater.Infrastructure.Auth.Services;
using MovieTheater.Infrastructure.Auth.Services.Interfaces;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(
        IAuthService authService,
        IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(UserSignupModel model)
    {
        var user = await _authService.SignupUser(model);
        return Ok(_mapper.Map<UserResponse>(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        return Ok(await _authService.Login(model));
    }
}