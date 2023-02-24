using MediatR;
using MovieTheater.Application.Shared.Genre;

namespace MovieTheater.Application.Genres.Queries.GetGenreById;

public class GetGenreByIdQuery: IRequest<GenreModel>
{
    public Guid Id { get; set; }
}