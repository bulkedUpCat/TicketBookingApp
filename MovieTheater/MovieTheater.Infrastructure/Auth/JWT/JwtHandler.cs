using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Auth.JWT;

/// <summary>
/// Class helper for generating a Jwt token
/// </summary>
public class JwtHandler : IJwtHandler
{
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<User> _userManager;

    /// <summary>
    /// Constructor which accepts configuration class and UserManager
    /// </summary>
    /// <param name="jwtSettings"></param>
    /// <param name="userManager">Instance of UserManager class to work with users</param>
    public JwtHandler(
        IOptions<JwtSettings> jwtSettings,
        UserManager<User> userManager)
    {
        _jwtSettings = jwtSettings.Value;
        _userManager = userManager;
    }

    /// <summary>
    /// Generates signing credentials using configuration from appsettings.json
    /// </summary>
    /// <returns>Generated signing credentials</returns>
    public SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    /// <summary>
    /// Creates claims for specified user
    /// </summary>
    /// <param name="user">Instance of User class whose claims are to be generated</param>
    /// <returns>List of generated claims of the user</returns>
    public async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        claims.AddRange(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

        return claims;
    }

    /// <summary>
    /// Generated a Jwt token using signing credentials along with list of claims
    /// </summary>
    /// <param name="signingCredentials">Instance of SigningCredentials class</param>
    /// <param name="claims">List of claims of the user</param>
    /// <returns>Generated Jwt token</returns>
    public JwtSecurityToken GenerateToken(SigningCredentials signingCredentials,
        IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials);

        return token;
    }
}