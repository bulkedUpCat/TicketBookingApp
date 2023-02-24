using MediatR;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommand: IRequest<ReservationModel>
{
    public Guid UserId { get; set; }
    public Guid ScreeningId { get; set; }
    public List<Guid> SeatIds { get; set; }
}