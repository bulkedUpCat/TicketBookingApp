using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class GenreRepository: IGenreRepository
{
    private readonly IMovieTheaterDbContext _context;

    public GenreRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Genres
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Genre>> GetAllByIds(
        IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        return await _context.Genres
            .Where(g => ids.Contains(g.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Genres
            .Include(g => g.Movies)
            .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        await _context.Genres.AddAsync(genre, cancellationToken);
    }

    public void Delete(Genre genre)
    {
        _context.Genres.Remove(genre);
    }
}