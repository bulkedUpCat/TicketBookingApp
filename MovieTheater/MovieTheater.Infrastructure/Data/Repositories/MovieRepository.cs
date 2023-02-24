using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;
using MovieTheater.Domain.Models;
using MovieTheater.Infrastructure.Extensions.IQueryableExtensions;

namespace MovieTheater.Infrastructure.Data.Repositories;

public class MovieRepository: IMovieRepository
{
    private readonly IMovieTheaterDbContext _context;

    public MovieRepository(IMovieTheaterDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(
        MovieFilter filter, 
        CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.ProductionCompany)
            .Include(m => m.ProductionCountries)
            .Include(m => m.MovieLanguages)
            .FilterByTitle(filter.Title)
            .FilterByRuntime(filter.Runtime)
            .FilterByGenres(filter.Genres)
            .FilterByCompanies(filter.Companies)
            .FilterByCountries(filter.Countries)
            .Sort(filter.SortingOption)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> GetTop3MoviesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .OrderByDescending(m => m.IMDbRating)
            .Take(3).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> GetComingSoonMoviesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Where(m => m.DateReleased > DateTime.UtcNow)
            .ToListAsync(cancellationToken);
    }

    public Task<IEnumerable<Movie>> Get5MostIncomeMoviesAsync(CancellationToken cancellationToken = default)
    {
        /*return await _context.Movies
            .Include(m => m.Screenings)
            .ThenInclude(s => s.Reservations)
            .ThenInclude(r => r.ReservedSeats)
            .GroupBy(m => m.Screenings)
            .GroupBy()*/
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Movie>> GetLatestMoviesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.ProductionCompany)
            .Include(m => m.ProductionCountries)
            .Include(m => m.MovieLanguages)
            .Where(m => m.DateReleased >= DateTime.UtcNow.AddDays(-30) && m.DateReleased <= DateTime.UtcNow)
            .ToListAsync(cancellationToken);
    }
    
    public async Task<IEnumerable<Movie>> GetMoviesWithScreeningsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.ProductionCompany)
            .Include(m => m.ProductionCountries)
            .Include(m => m.MovieLanguages)
            .Include(m => m.Screenings)
            .Where(m => m.Screenings.Count != 0)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Movie>> GetLastChanceMoviesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.ProductionCompany)
            .Include(m => m.ProductionCountries)
            .Include(m => m.MovieLanguages)
            .Include(m => m.Screenings)
            .Where(m => m.Screenings.OrderByDescending(s => s.Start).First() != null &&
                        m.Screenings.OrderByDescending(s => s.Start).First().Start <= DateTime.UtcNow.AddDays(7))
            .ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Movies
            .Include(m => m.Genres)
            .Include(m => m.Screenings)
            .Include(m => m.ProductionCompany)
            .Include(m => m.ProductionCountries)
            .Include(m => m.MovieLanguages)
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await _context.Movies
            .AddAsync(movie, cancellationToken);
    }

    public void Update(Movie movie)
    {
        _context.Movies.Update(movie);
    }

    public void Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
    }
}