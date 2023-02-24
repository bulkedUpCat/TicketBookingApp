namespace MovieTheater.Application.Shared.Reservation;

public class ReservationModel
{
    public Guid Id { get; set; }
    public Guid ScreeningId { get; set; }
    public Guid UserId { get; set; }
    public bool Paid { get; set; }
    public IEnumerable<Guid> ReservedSeats { get; set; }
}