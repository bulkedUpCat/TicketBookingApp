using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetMovieById;

public class GetMovieByIdQuery: IRequest<MovieModel>
{
    public Guid Id { get; set; }
}