using MediatR;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetScreeningById;

public class GetScreeningByIdQuery: IRequest<ScreeningModel>
{
    public Guid Id { get; set; }
}