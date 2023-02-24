namespace MovieTheater.Application.Exceptions.NotFoundException;

public class ReservationNotFoundException: NotFoundException
{
    public ReservationNotFoundException(Guid id): base($"Reservation with id {id} was not found"){}

    public ReservationNotFoundException(): base("Reservation was not found"){}
}