using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Movie;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler: IRequestHandler<CreateMovieCommand, MovieModel>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(
        IMovieRepository movieRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovieModel> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = _mapper.Map<Movie>(request);
        movie.DateReleased = movie.DateReleased.AddDays(1);

        await _movieRepository.CreateAsync(movie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MovieModel>(movie);
    }
}