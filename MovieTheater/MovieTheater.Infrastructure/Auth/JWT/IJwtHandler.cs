using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Auth.JWT;

public interface IJwtHandler
{
    SigningCredentials GetSigningCredentials();
    Task<List<Claim>> GetClaimsAsync(User user);
    JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
}