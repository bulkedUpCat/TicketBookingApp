using AutoMapper;
using MovieTheater.Domain.Entities;
using MovieTheater.Infrastructure.Auth.Models;

namespace MovieTheater.Infrastructure.Auth.Profiles;

public class AuthProfile: Profile
{
    public AuthProfile()
    {
        CreateMap<UserSignupModel, User>();
        CreateMap<User, UserResponse>();
    }
}