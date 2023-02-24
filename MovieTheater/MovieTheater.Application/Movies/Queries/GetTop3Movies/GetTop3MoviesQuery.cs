using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetTop3Movies;

public class GetTop3MoviesQuery: IRequest<IEnumerable<MovieModel>>
{
    
}