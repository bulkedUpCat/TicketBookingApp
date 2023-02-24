using AutoMapper;
using MovieTheater.Application.Movies.Commands.CreateMovie;
using MovieTheater.Application.Movies.Queries.GetMovieList;
using MovieTheater.Application.Shared.Movie;
using MovieTheater.Domain.Entities;
using MovieTheater.Domain.Models;

namespace MovieTheater.Application.Common.Profiles;

public class MovieProfile: Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieModel>()
            .ForMember(dest => dest.Countries, src => src.MapFrom(opt => opt.ProductionCountries))
            .ForMember(dest => dest.Languages, src => src.MapFrom(opt => opt.MovieLanguages));
        
        CreateMap<GetMovieListQuery, MovieFilter>();
        
        CreateMap<CreateMovieCommand, Movie>();
    }
}