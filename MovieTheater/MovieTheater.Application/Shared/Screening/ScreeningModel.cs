using MovieTheater.Application.Shared.Hall;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Shared.Screening;

public class ScreeningModel
{
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public decimal Price { get; set; }
    public string MovieTitle { get; set; }
    public MovieModel Movie { get; set; }
    public Guid MovieId { get; set; }
    public HallModel Hall { get; set; }
    public Guid HallId { get; set; }
    public Guid? MovieLanguageId { get; set; }
    public IEnumerable<Guid> Reservations { get; set; }
}