using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IProductionCompanyRepository
{
    Task<IEnumerable<ProductionCompany>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductionCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(ProductionCompany productionCompany, CancellationToken cancellationToken = default);
    void Update(ProductionCompany productionCompany);
    void Delete(ProductionCompany productionCompany);
}