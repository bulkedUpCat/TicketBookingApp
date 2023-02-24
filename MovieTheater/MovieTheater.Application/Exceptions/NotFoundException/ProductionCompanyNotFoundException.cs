namespace MovieTheater.Application.Exceptions.NotFoundException;

public class ProductionCompanyNotFoundException: NotFoundException
{
    public ProductionCompanyNotFoundException(Guid id) : base($"Production company with id {id} was not found"){}
}