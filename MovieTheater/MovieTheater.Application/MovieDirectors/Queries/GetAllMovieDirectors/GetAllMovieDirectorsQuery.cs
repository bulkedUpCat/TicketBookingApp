using MediatR;
using MovieTheater.Application.Shared.MovieDirector;

namespace MovieTheater.Application.MovieDirectors.Queries.GetAllMovieDirectors;

public class GetAllMovieDirectorsQuery: IRequest<IEnumerable<MovieDirectorModel>>
{
    
}