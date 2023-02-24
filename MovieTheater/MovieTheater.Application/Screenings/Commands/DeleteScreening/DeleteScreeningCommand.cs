using MediatR;

namespace MovieTheater.Application.Screenings.Commands.DeleteScreening;

public class DeleteScreeningCommand: IRequest
{
    public Guid Id { get; set; }
}