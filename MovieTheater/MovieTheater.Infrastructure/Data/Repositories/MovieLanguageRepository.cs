using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class MovieLanguageRepository: IMovieLanguageRepository
{
    private readonly IMovieTheaterDbContext _context;

    public MovieLanguageRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieLanguage>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.MovieLanguages
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<MovieLanguage>> GetAllByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default)
    {
        return await _context.MovieLanguages
            .Include(ml => ml.Movies)
            .Where(ml => ml.Movies.Any(m => m.Id == movieId))
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<MovieLanguage>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _context.MovieLanguages
            .Where(l => ids.Contains(l.Id))
            .ToListAsync(cancellationToken);
    }

    public async Task<MovieLanguage?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.MovieLanguages
            .FirstOrDefaultAsync(ml => ml.Id == id, cancellationToken);
    }

    public async Task CreateAsync(MovieLanguage language, CancellationToken cancellationToken = default)
    {
        await _context.MovieLanguages.AddAsync(language, cancellationToken);
    }

    public void Delete(MovieLanguage language)
    {
        _context.MovieLanguages.Remove(language);
    }
}