using MediatR;

namespace MovieTheater.Application.Movies.Queries.GetMovieList;

public class GetMovieListQuery : IRequest<MovieListModel>
{
    public string? Title { get; set; }
    public List<int>? Runtime { get; set; }
    public List<string>? Companies { get; set; }
    public List<string>? Genres { get; set; }
    public List<string>? Countries { get; set; }
    public string? SortingOption { get; set; }
}