using MovieTheater.Application.Shared.Seat;

namespace MovieTheater.Application.Shared.Hall;

public class HallModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<SeatModel> Seats { get; set; }
    public int SeatsNumber { get; set; }
    public int RowsNumber { get; set; }
}