using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class ScreeningRepository: IScreeningRepository
{
    private readonly IMovieTheaterDbContext _context;

    public ScreeningRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Screening>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Screenings
            .OrderBy(s => s.Start)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Screening>> GetAllByHallId(Guid hallId, CancellationToken cancellationToken = default)
    {
        return await _context.Screenings
            .Where(s => s.HallId == hallId)
            .Include(s => s.Movie)
            .OrderBy(s => s.Start)
            .ToListAsync(cancellationToken);
    }

    public async Task<Screening?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Screenings
            .Include(s => s.Movie)
            .Include(s => s.Hall)
            .Include(s => s.Reservations)
            .OrderBy(s => s.Start)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Screening screening, CancellationToken cancellationToken = default)
    {
        await _context.Screenings.AddAsync(screening, cancellationToken);
    }

    public void Delete(Screening screening)
    {
        _context.Screenings.Remove(screening);
    }
}