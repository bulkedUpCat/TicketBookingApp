using MediatR;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationsByUserId;

public class GetReservationsByUserIdQuery: IRequest<IEnumerable<ReservationModel>>
{
    public string UserId { get; set; }
}