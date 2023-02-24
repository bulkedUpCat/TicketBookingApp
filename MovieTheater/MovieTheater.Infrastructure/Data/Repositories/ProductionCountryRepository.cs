using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class ProductionCountryRepository: IProductionCountryRepository
{
    private readonly IMovieTheaterDbContext _context;

    public ProductionCountryRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductionCountry>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ProductionCountries.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<ProductionCountry>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        return await _context.ProductionCountries
            .Where(c => ids.Contains(c.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductionCountry?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.ProductionCountries
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task CreateAsync(ProductionCountry country, CancellationToken cancellationToken)
    {
        await _context.ProductionCountries.AddAsync(country, cancellationToken);
    }

    public void Delete(ProductionCountry country)
    {
        _context.ProductionCountries.Remove(country);
    }
}