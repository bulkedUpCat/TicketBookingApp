using MediatR;
using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Seats.Queries.GetAllSeats;

public class GetAllSeatsQuery: IRequest<IEnumerable<SeatModel>>
{
    
}