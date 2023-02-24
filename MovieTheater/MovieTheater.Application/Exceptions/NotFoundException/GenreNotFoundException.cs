namespace MovieTheater.Application.Exceptions.NotFoundException;

public class GenreNotFoundException: NotFoundException
{
    public GenreNotFoundException(): base("Failed to find a genre"){}
    public GenreNotFoundException(Guid id): base($"Genre with id {id} was not found"){}
}