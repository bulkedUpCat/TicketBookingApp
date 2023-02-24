using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Screening;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Screenings.Commands.CreateScreening;

public class CreateScreeningCommandHandler: IRequestHandler<CreateScreeningCommand, ScreeningModel>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IHallRepository _hallRepository;
    private readonly IMovieLanguageRepository _movieLanguageRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateScreeningCommandHandler(
        IScreeningRepository screeningRepository, 
        IMovieRepository movieRepository,
        IHallRepository hallRepository,
        IMovieLanguageRepository movieLanguageRepository,
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _screeningRepository = screeningRepository;
        _movieRepository = movieRepository;
        _hallRepository = hallRepository;
        _movieLanguageRepository = movieLanguageRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<ScreeningModel> Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        request.Start = request.Start.AddHours(2);
        var movie = await _movieRepository.GetByIdAsync(request.MovieId, cancellationToken);

        if (movie == null)
        {
            throw new MovieNotFoundException(request.MovieId);
        }

        var hall = await _hallRepository.GetByIdAsync(request.HallId, cancellationToken);

        if (hall == null)
        {
            throw new HallNotFoundException(request.HallId);
        }

        var movieLanguage = await _movieLanguageRepository.GetByIdAsync(request.MovieLanguageId, cancellationToken);

        if (movieLanguage == null)
        {
            throw new MovieLanguageNotFoundException(request.MovieLanguageId);
        }
            
        var screening = _mapper.Map<Screening>(request);

        await _screeningRepository.CreateAsync(screening, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ScreeningModel>(screening);
    }
}