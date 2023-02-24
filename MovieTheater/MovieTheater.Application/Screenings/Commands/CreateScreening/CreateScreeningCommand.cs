using MediatR;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Commands.CreateScreening;

public class CreateScreeningCommand: IRequest<ScreeningModel>
{
    public DateTime Start { get; set; }
    public decimal Price { get; set; }
    public Guid MovieId { get; set; }
    public Guid HallId { get; set; }
    public Guid MovieLanguageId { get; set; }
}