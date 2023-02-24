namespace MovieTheater.Application.Exceptions.NotFoundException;

public class HallNotFoundException: NotFoundException
{
    public HallNotFoundException(Guid id): base($"Hall with id {id} was not found"){}
}