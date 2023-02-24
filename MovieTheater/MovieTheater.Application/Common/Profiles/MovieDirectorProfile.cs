using AutoMapper;
using MovieTheater.Application.Shared.MovieDirector;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class MovieDirectorProfile: Profile
{
    public MovieDirectorProfile()
    {
        CreateMap<MovieDirector, MovieDirectorModel>();
    }
}