using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Extensions.IQueryableExtensions;

public static class MovieRepositoryExtensions
{
    public static IQueryable<Movie> FilterByTitle(this IQueryable<Movie> movies, string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return movies;
        }

        return movies
            .Where(m => m.Title.ToLower().Contains(title.ToLower()));
    }

    public static IQueryable<Movie> FilterByGenres(
        this IQueryable<Movie> movies, 
        List<string>? genreNames)
    {
        if (genreNames == null || !genreNames.Any())
        {
            return movies;
        }

        return movies
            .Where(m => m.Genres.Any(g => genreNames.Any(gn => g.Name == gn)));
    }

    public static IQueryable<Movie> FilterByRuntime(
        this IQueryable<Movie> movies,
        List<int>? runtimes)
    {
        if (runtimes == null || !runtimes.Any())
        {
            return movies;
        }

        return movies
            .Where(m => m.DurationMinutes >= runtimes.Min());
    }

    public static IQueryable<Movie> FilterByCompanies(
        this IQueryable<Movie> movies,
        List<string>? companies)
    {
        if (companies == null || !companies.Any())
        {
            return movies;
        }

        return movies
            .Where(m => companies.Any(c => m.ProductionCompany.Name == c));
    }

    public static IQueryable<Movie> FilterByCountries(
        this IQueryable<Movie> movies,
        List<string>? countries)
    {
        if (countries == null || !countries.Any())
        {
            return movies;
        }

        return movies
            .Where(m => m.ProductionCountries.Any(c => countries.Any(cn => c.Name == cn)));
    }

    public static IQueryable<Movie> Sort(
        this IQueryable<Movie> movies,
        string? sortingOption)
    {
        if (string.IsNullOrWhiteSpace(sortingOption))
        {
            return movies;
        }

        return sortingOption switch
        {
            "Runtime" => movies.OrderByDescending(m => m.DurationMinutes),
            "Release date" => movies.OrderByDescending(m => m.DateReleased),
            "Title" => movies.OrderBy(m => m.Title),
            "IMDb rating" => movies.OrderByDescending(m => m.IMDbRating),
            _ => movies
        };
    }
}