using MediatR;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguagesByMovieId;

public class GetAllMovieLanguagesByMovieIdQuery: IRequest<IEnumerable<MovieLanguageModel>>
{
    public Guid MovieId { get; set; }
}