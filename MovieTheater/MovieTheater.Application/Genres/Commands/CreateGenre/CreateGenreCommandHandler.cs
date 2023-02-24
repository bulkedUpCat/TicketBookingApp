using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Genre;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommandHandler: IRequestHandler<CreateGenreCommand, GenreModel>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(
        IGenreRepository genreRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GenreModel> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = _mapper.Map<Genre>(request);

        await _genreRepository.CreateAsync(genre, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GenreModel>(genre);
    }
}