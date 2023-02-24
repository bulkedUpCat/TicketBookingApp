namespace MovieTheater.Application.Exceptions.NotFoundException;

public class ScreeningNotFoundException: NotFoundException
{
    public ScreeningNotFoundException(Guid id): base($"Screening with id {id} was not found"){}
}