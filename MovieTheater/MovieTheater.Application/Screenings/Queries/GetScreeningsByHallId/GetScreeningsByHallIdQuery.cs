using MediatR;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetScreeningsByHallId;

public class GetScreeningsByHallIdQuery: IRequest<IEnumerable<ScreeningModel>>
{
    public Guid HallId { get; set; }
}