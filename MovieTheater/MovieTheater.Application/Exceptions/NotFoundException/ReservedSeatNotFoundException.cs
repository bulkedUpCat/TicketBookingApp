namespace MovieTheater.Application.Exceptions.NotFoundException;

public class ReservedSeatNotFoundException: NotFoundException
{
    public ReservedSeatNotFoundException(Guid id) : base($"Reserved seat with id {id} was not found"){}
}