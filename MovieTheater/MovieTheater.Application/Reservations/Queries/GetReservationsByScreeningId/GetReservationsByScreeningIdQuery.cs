using MediatR;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationsByScreeningId;

public class GetReservationsByScreeningIdQuery: IRequest<IEnumerable<ReservationModel>>
{
    public Guid ScreeningId { get; set; }
}