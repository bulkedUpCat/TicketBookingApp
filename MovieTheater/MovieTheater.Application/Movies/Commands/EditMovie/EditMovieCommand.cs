using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Commands.EditMovie;

public class EditMovieCommand: IRequest<MovieModel>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateReleased { get; set; }
    public decimal Budget { get; set; }
    public double IMDbRating { get; set; }
    public decimal Revenue { get; set; }
    public string Poster { get; set; }
    public int DurationMinutes { get; set; }
    public Guid ProductionCompany { get; set; }
    public IEnumerable<Guid> Genres { get; set; }
    public IEnumerable<Guid> Countries { get; set; }
    public IEnumerable<Guid> Languages { get; set; }
}