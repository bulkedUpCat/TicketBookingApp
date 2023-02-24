using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetAllMovieLanguagesByMovieId;

public class GetAllMovieLanguagesByMovieIdQueryHandler: IRequestHandler<GetAllMovieLanguagesByMovieIdQuery, IEnumerable<MovieLanguageModel>>
{
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMapper _mapper;
    
    public GetAllMovieLanguagesByMovieIdQueryHandler(
        IMovieLanguageRepository movieLanguageRepository, 
        IMapper mapper)
    {
        _movieLanguageRepository = movieLanguageRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<MovieLanguageModel>> Handle(GetAllMovieLanguagesByMovieIdQuery request, CancellationToken cancellationToken)
    {
        var movieLanguages = 
            await _movieLanguageRepository.GetAllByMovieIdAsync(request.MovieId, cancellationToken);
        return _mapper.Map<IEnumerable<MovieLanguageModel>>(movieLanguages);
    }
}