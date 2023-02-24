using MediatR;
using MovieTheater.Application.Shared.Reservation;

namespace MovieTheater.Application.Reservations.Queries.GetReservationById;

public class GetReservationByIdQuery: IRequest<ReservationModel>
{
    public Guid Id { get; set; }
}