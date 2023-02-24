using AutoMapper;
using MovieTheater.Application.Screenings.Commands.CreateScreening;
using MovieTheater.Application.Shared.Screening;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class ScreeningProfile: Profile
{
    public ScreeningProfile()
    {
        CreateMap<Screening, ScreeningModel>()
            .ForMember(dest => dest.MovieTitle, src => src.MapFrom(opt => opt.Movie.Title))
            .ForMember(dest => dest.Reservations, src => src.MapFrom(opt => opt.Reservations.Select(r => r.Id)));

        CreateMap<CreateScreeningCommand, Screening>();
    }
}