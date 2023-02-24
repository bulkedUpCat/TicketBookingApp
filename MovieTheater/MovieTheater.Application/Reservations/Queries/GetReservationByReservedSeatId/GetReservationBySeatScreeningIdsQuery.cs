using MediatR;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationByReservedSeatId;

public class GetReservationBySeatScreeningIdsQuery: IRequest<ReservationModel>
{
    public Guid SeatId { get; set; }
    public Guid ScreeningId { get; set; }
}