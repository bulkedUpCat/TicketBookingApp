using MediatR;
using MovieTheater.Application.Shared.Genre;

namespace MovieTheater.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommand: IRequest<GenreModel>
{
    public string Name { get; set; }
}