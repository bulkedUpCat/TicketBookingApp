using MediatR;
using MovieTheater.Application.Shared.ReservedSeat;

namespace MovieTheater.Application.ReservedSeats.Queries.GetReservedSeatById;

public class GetReservedSeatByIdQuery: IRequest<ReservedSeatModel>
{
    public Guid Id { get; set; }
}