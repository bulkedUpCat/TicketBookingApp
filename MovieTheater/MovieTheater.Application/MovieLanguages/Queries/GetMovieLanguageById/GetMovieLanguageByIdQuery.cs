using MediatR;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetMovieLanguageById;

public class GetMovieLanguageByIdQuery: IRequest<MovieLanguageModel>
{
    public Guid Id { get; set; }
}