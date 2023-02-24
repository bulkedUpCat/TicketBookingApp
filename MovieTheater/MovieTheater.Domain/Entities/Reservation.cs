namespace MovieTheater.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }

    public virtual Screening Screening { get; set; }
    public Guid ScreeningId { get; set; }

    public virtual User User { get; set; }
    public string UserId { get; set; }
    public DateTime ValidTo { get; set; }
    public bool Paid { get; set; }

    public virtual ICollection<ReservedSeat> ReservedSeats { get; set; }
}