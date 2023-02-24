using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetLatestMovies;

public class GetLatestMoviesQuery: IRequest<IEnumerable<MovieModel>>
{
    
}