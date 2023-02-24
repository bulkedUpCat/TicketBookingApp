using MediatR;
using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommand: IRequest<MovieModel>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateReleased { get; set; }
    public decimal Budget { get; set; }
    public double IMDbRating { get; set; }
    public decimal Revenue { get; set; }
    public string Poster { get; set; }
    public int DurationMinutes { get; set; }
}