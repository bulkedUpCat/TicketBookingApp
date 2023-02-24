using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.MovieLanguage;

namespace MovieTheater.Application.MovieLanguages.Queries.GetMovieLanguageById;

public class GetMovieLanguageByIdQueryHandler: IRequestHandler<GetMovieLanguageByIdQuery, MovieLanguageModel>
{
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMapper _mapper;

    public GetMovieLanguageByIdQueryHandler(
        IMovieLanguageRepository movieLanguageRepository, 
        IMapper mapper)
    {
        _movieLanguageRepository = movieLanguageRepository;
        _mapper = mapper;
    }

    public async Task<MovieLanguageModel> Handle(GetMovieLanguageByIdQuery request, CancellationToken cancellationToken)
    {
        var movieLanguage = await _movieLanguageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (movieLanguage == null)
        {
            throw new MovieLanguageNotFoundException(request.Id);
        }

        return _mapper.Map<MovieLanguageModel>(movieLanguage);
    }
}