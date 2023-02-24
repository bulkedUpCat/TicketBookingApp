namespace MovieTheater.Domain.Entities;

public class Movie
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

    public Guid? MovieDirectorId { get; set; }
    public virtual MovieDirector MovieDirector { get; set; }

    public Guid? ProductionCompanyId { get; set; }
    public virtual ProductionCompany ProductionCompany { get; set; }

    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Screening> Screenings { get; set; }
    public virtual ICollection<ProductionCountry> ProductionCountries { get; set; }
    public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }
    public virtual ICollection<MovieImage> MovieImages { get; set; }
}