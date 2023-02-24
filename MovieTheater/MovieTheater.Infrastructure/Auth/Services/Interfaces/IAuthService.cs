using MovieTheater.Domain.Entities;
using MovieTheater.Infrastructure.Auth.Models;

namespace MovieTheater.Infrastructure.Auth.Services.Interfaces;

public interface IAuthService
{
    Task<User> SignupUser(UserSignupModel model);
    Task<JwtResponse> Login(UserLoginModel model);
}