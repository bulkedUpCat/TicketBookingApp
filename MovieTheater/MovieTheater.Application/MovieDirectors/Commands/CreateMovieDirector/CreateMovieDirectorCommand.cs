using MediatR;
using MovieTheater.Application.Shared.MovieDirector;

namespace MovieTheater.Application.MovieDirectors.Commands.CreateMovieDirector;

public class CreateMovieDirectorCommand: IRequest<MovieDirectorModel>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public double Rank { get; set; }
}