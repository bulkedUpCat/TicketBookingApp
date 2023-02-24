using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class MovieDirectorRepository: IMovieDirectorRepository
{
    private readonly IMovieTheaterDbContext _context;

    public MovieDirectorRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieDirector>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.MovieDirectors
            .ToListAsync(cancellationToken);
    }

    public async Task<MovieDirector?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.MovieDirectors
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public async Task CreateAsync(MovieDirector director, CancellationToken cancellationToken = default)
    {
        await _context.MovieDirectors.AddAsync(director, cancellationToken);
    }

    public void Delete(MovieDirector director)
    {
        _context.MovieDirectors.Remove(director);
    }
}