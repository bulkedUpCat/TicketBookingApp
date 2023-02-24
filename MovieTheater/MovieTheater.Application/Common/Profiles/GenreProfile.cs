using AutoMapper;
using MovieTheater.Application.Genres.Commands.CreateGenre;
using MovieTheater.Application.Shared.Genre;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class GenreProfile: Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GenreModel>();
        CreateMap<CreateGenreCommand, Genre>();
    }
}