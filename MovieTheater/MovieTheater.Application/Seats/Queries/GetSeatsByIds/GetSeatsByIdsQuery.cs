using MediatR;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetSeatsByIds;

public class GetSeatsByIdsQuery: IRequest<IEnumerable<SeatModel>>
{
    public Guid[] Ids { get; set; }
}