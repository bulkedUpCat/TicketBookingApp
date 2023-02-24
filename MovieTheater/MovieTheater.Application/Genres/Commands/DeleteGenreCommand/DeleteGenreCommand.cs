using MediatR;

namespace MovieTheater.Application.Genres.Commands.DeleteGenreCommand;

public class DeleteGenreCommand: IRequest
{
    public Guid Id { get; set; }
}