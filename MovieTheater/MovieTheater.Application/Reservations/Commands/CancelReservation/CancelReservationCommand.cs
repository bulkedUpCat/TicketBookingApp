using MediatR;

namespace MovieTheater.Application.Reservations.Commands.CancelReservation;

public class CancelReservationCommand: IRequest
{
    public Guid ReservationId { get; set; }
}