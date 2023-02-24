namespace MovieTheater.Application.Shared.Seat;

public class SeatModel
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Number { get; set; }
    public decimal PriceOffset { get; set; }
    public Guid HallId { get; set; }
    public IEnumerable<Guid> Reservations { get; set; }
    public IEnumerable<Guid> ReservedScreenings { get; set; }
}