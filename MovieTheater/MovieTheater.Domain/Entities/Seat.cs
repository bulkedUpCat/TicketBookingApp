namespace MovieTheater.Domain.Entities;

public class Seat
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Number { get; set; }
    public decimal PriceOffset { get; set; }
    public virtual Hall Hall { get; set; }
    public Guid HallId { get; set; }

    public virtual ICollection<ReservedSeat> ReservedSeats { get; set; }
}