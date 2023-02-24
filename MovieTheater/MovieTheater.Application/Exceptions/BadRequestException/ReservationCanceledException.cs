namespace MovieTheater.Application.Exceptions.BadRequestException;

public class ReservationCanceledException: Exception
{
    public ReservationCanceledException(): base("Reservation was canceled"){}
}