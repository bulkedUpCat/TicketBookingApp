namespace MovieTheater.Domain.Entities;

public class ReservedSeat
{
    public Guid Id { get; set; }

    public virtual Seat Seat { get; set; }
    public Guid SeatId { get; set; }

    public virtual Reservation Reservation { get; set; }
    public Guid ReservationId { get; set; }
}