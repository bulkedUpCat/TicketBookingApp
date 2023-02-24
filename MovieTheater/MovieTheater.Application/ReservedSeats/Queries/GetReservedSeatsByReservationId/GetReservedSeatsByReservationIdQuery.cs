using MediatR;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatsByReservationId;

public class GetReservedSeatsByReservationIdQuery: IRequest<IEnumerable<ReservedSeatModel>>
{
    public Guid ReservationId { get; set; }
}