namespace MovieTheater.Application.Exceptions.NotFoundException;

public class SeatNotFoundException : NotFoundException
{
    public SeatNotFoundException(Guid id) : base($"Seat with id {id} was not found"){}
}