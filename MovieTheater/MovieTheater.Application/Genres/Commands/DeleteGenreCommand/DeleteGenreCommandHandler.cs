using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Genres.Commands.DeleteGenreCommand;

public class DeleteGenreCommandHandler: IRequestHandler<DeleteGenreCommand, Unit>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public DeleteGenreCommandHandler(
        IGenreRepository genreRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (genre == null)
        {
            throw new GenreNotFoundException(request.Id);
        }
        
        _genreRepository.Delete(genre);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}