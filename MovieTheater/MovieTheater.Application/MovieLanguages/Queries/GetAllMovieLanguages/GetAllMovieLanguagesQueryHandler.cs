using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguages;

public class GetAllMovieLanguagesQueryHandler: IRequestHandler<GetAllMovieLanguagesQuery, IEnumerable<MovieLanguageModel>>
{
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMapper _mapper;

    public GetAllMovieLanguagesQueryHandler(
        IMovieLanguageRepository movieLanguageRepository, 
        IMapper mapper)
    {
        _movieLanguageRepository = movieLanguageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieLanguageModel>> Handle(GetAllMovieLanguagesQuery request, CancellationToken cancellationToken)
    {
        var movieLanguages = await _movieLanguageRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MovieLanguageModel>>(movieLanguages);
    }
}