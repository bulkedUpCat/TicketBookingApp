using MediatR;

namespace MovieTheater.Application.Reservations.Commands.ChangeReservationStatusToPaid;

public class ChangeReservationStatusToPaidCommand: IRequest<Unit>
{
    public Guid Id { get; set; }
}