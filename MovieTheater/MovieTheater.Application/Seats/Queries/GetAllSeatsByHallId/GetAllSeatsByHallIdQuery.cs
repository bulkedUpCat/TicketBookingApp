using MediatR;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetAllSeatsByHallId;

public class GetAllSeatsByHallIdQuery: IRequest<IEnumerable<SeatModel>>
{
    public Guid HallId { get; set; }
}