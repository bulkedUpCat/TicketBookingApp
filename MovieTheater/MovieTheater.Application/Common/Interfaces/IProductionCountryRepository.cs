using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IProductionCountryRepository
{
    Task<IEnumerable<ProductionCountry>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<ProductionCountry>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    Task<ProductionCountry?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(ProductionCountry country, CancellationToken cancellationToken);
    void Delete(ProductionCountry country);
}