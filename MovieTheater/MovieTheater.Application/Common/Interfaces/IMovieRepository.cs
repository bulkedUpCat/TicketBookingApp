using MovieTheater.Domain.Entities;
using MovieTheater.Domain.Models;

namespace MovieTheater.Application.Common.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(MovieFilter filter, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetTop3MoviesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> Get5MostIncomeMoviesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetComingSoonMoviesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetLatestMoviesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetLastChanceMoviesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetMoviesWithScreeningsAsync(CancellationToken cancellationToken = default);
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Movie movie, CancellationToken cancellationToken = default);
    void Update(Movie movie);
    void Delete(Movie movie);
}