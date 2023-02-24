using MovieTheater.Application.Shared.Movie;

namespace MovieTheater.Application.Movies.Queries.GetMovieList;

public class MovieListModel
{
    public IEnumerable<MovieModel> Movies { get; set; }
}