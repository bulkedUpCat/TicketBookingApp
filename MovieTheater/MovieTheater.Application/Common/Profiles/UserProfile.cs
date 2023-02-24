using AutoMapper;
using MovieTheater.Application.Shared.User;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>()
            .ForMember(dest => dest.Id, src => src.MapFrom(opt => new Guid(opt.Id)));
    }
}