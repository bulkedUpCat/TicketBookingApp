using AutoMapper;
using MovieTheater.Api.Models;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Api.Profiles;

public class MovieProfile: Profile
{
    public MovieProfile()
    {
        CreateMap<ExternalMovieModel, MovieModel>()
            .ForMember(dest => dest.Id, src => src.MapFrom(opt => Guid.NewGuid()))
            .ForMember(dest => dest.Poster,
                src => src.MapFrom(opt => "https://image.tmdb.org/t/p/original" + opt.Poster));
        //.ForMember(dest => dest.DurationMinutes, src => src.MapFrom(opt => new Random().Next(100, 300)))
        //.ForMember(dest => dest.IMDbRating, src => src.MapFrom(opt => new Random().Next(5, 10)));
    }
}