using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetComingSoonMovies;

public class GetComingSoonMoviesQuery: IRequest<IEnumerable<MovieModel>>
{
    
}