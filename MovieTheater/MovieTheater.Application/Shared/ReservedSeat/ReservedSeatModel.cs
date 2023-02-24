namespace MovieTheater.Application.Shared.ReservedSeat;

public class ReservedSeatModel
{
    public Guid Id { get; set; }
    public Guid SeatId { get; set; }
    public int Row { get; set; }
    public int Number { get; set; }
}