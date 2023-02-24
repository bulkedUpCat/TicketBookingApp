namespace MovieTheater.Application.Exceptions.NotFoundException;

public class MovieLanguageNotFoundException: NotFoundException
{
    public MovieLanguageNotFoundException(Guid id) : base($"Movie language with id {id} was not found"){}
}