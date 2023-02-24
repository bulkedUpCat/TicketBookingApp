using MediatR;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetSeatById;

public class GetSeatByIdQuery: IRequest<SeatModel>
{
    public Guid Id { get; set; }
}