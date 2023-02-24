using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class ProductionCompanyRepository: IProductionCompanyRepository
{
    private readonly IMovieTheaterDbContext _context;
    
    public ProductionCompanyRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductionCompany>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ProductionCompanies
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductionCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ProductionCompanies
            .Where(pc => pc.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task CreateAsync(ProductionCompany productionCompany, CancellationToken cancellationToken = default)
    {
        await _context.ProductionCompanies.AddAsync(productionCompany, cancellationToken);
    }

    public void Update(ProductionCompany productionCompany)
    {
        _context.ProductionCompanies.Update(productionCompany);
    }

    public void Delete(ProductionCompany productionCompany)
    {
        _context.ProductionCompanies.Remove(productionCompany);
    }
}