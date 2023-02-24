using MediatR;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetAllScreenings;

public class GetAllScreeningsQuery: IRequest<IEnumerable<ScreeningModel>>
{
    
}