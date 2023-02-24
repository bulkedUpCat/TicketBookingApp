using MediatR;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Commands.CreateMovieLanguage;

public class CreateMovieLanguageCommand: IRequest<MovieLanguageModel>
{
    public string Name { get; set; }
}