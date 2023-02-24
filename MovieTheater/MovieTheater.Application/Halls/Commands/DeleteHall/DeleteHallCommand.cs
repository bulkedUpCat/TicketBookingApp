using MediatR;

namespace MovieTheater.Application.Halls.Commands.DeleteHall;

public class DeleteHallCommand: IRequest
{
    public Guid Id { get; set; }
}