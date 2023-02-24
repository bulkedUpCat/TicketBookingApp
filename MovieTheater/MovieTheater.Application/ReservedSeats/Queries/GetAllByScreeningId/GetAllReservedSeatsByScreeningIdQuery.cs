using MediatR;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetAllByScreeningId;

public class GetAllReservedSeatsByScreeningIdQuery: IRequest<IEnumerable<ReservedSeatModel>>
{
    public Guid ScreeningId { get; set; }
}