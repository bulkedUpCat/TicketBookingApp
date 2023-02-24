using MovieTheater.Application.Shared.Genre;
using MovieTheater.Application.Shared.MovieLanguage;
using MovieTheater.Application.Shared.ProductionCompany;
using MovieTheater.Application.Shared.ProductionCountry;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Shared.Movie;

public class MovieModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateReleased { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Budget { get; set; }
    public double IMDbRating { get; set; }
    public decimal Revenue { get; set; }
    public string Poster { get; set; }
    public ProductionCompanyModel ProductionCompany { get; set; }
    public IEnumerable<ScreeningModel> Screenings { get; set; }
    public IEnumerable<GenreModel> Genres { get; set; }
    public IEnumerable<ProductionCountryModel> Countries { get; set; }
    public IEnumerable<MovieLanguageModel> Languages { get; set; }
}