namespace MovieTheater.Application.Exceptions.NotFoundException;

public class ProductionCountryNotFoundException: NotFoundException
{
    public ProductionCountryNotFoundException(Guid id): base($"Production country with id {id} was not found"){}
}