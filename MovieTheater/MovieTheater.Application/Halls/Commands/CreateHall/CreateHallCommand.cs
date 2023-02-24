using MediatR;
using MovieTheater.Application.Shared.Hall;

namespace MovieTheater.Application.Halls.Commands.CreateHall;

public class CreateHallCommand: IRequest<HallModel>
{
    public string Name { get; set; }
    public int SeatsNumber { get; set; }
    public int SeatsInRow { get; set; }
    public decimal SeatPrice { get; set; } = 10m;
}