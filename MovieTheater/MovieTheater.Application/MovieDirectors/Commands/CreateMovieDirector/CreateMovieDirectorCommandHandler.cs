using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.MovieDirector;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.MovieDirectors.Commands.CreateMovieDirector;

public class CreateMovieDirectorCommandHandler: IRequestHandler<CreateMovieDirectorCommand, MovieDirectorModel>
{
    private readonly IMovieDirectorRepository _movieDirectorRepository;
    private readonly IMapper _mapper;
    private readonly IMovieTheaterDbContext _context;

    public CreateMovieDirectorCommandHandler(
        IMovieDirectorRepository movieDirectorRepository, 
        IMapper mapper,
        IMovieTheaterDbContext context)
    {
        _movieDirectorRepository = movieDirectorRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<MovieDirectorModel> Handle(CreateMovieDirectorCommand request, CancellationToken cancellationToken)
    {
        var movieDirector = _mapper.Map<MovieDirector>(request);

        await _movieDirectorRepository.CreateAsync(movieDirector, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MovieDirectorModel>(movieDirector);
    }
}