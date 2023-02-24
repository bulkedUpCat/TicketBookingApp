using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.MovieLanguage;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.MovieLanguages.Commands.CreateMovieLanguage;

public class CreateMovieLanguageCommandHandler: IRequestHandler<CreateMovieLanguageCommand, MovieLanguageModel>
{
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateMovieLanguageCommandHandler(
        IMovieLanguageRepository movieLanguageRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _movieLanguageRepository = movieLanguageRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieLanguageModel> Handle(CreateMovieLanguageCommand request, CancellationToken cancellationToken)
    {
        var movieLanguage = _mapper.Map<MovieLanguage>(request);

        await _movieLanguageRepository.CreateAsync(movieLanguage, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MovieLanguageModel>(movieLanguage);
    }
}