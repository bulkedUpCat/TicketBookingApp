using MediatR;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguages;

public class GetAllMovieLanguagesQuery: IRequest<IEnumerable<MovieLanguageModel>>
{
    
}