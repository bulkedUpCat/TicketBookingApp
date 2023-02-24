using MediatR;
using MovieTheater.Application.Shared.Hall;

namespace MovieTheater.Application.Halls.Queries.GetHallById;

public class GetHallByIdQuery: IRequest<HallModel>
{
    public Guid Id { get; set; }
}