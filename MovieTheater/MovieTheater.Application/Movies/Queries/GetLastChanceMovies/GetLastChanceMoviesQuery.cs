using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetLastChanceMovies;

public class GetLastChanceMoviesQuery: IRequest<IEnumerable<MovieModel>>
{
    
}