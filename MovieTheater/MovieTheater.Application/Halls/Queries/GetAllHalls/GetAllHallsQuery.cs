using MediatR;
using MovieTheater.Application.Shared.Hall;

namespace MovieTheater.Application.Halls.Queries.GetAllHalls;

public class GetAllHallsQuery: IRequest<IEnumerable<HallModel>>
{
    
}