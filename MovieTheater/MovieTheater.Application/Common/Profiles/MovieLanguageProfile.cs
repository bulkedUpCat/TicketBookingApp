using AutoMapper;
using MovieTheater.Application.MovieLanguages.Commands.CreateMovieLanguage;
using MovieTheater.Application.Shared.MovieLanguage;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class MovieLanguageProfile: Profile
{
    public MovieLanguageProfile()
    {
        CreateMap<MovieLanguage, MovieLanguageModel>();
        CreateMap<CreateMovieLanguageCommand, MovieLanguage>();
    }
}