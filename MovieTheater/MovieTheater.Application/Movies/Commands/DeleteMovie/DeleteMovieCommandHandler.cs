using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler: IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieTheaterDbContext _context;

    public DeleteMovieCommandHandler(
        IMovieRepository movieRepository, 
        IMovieTheaterDbContext context)
    {
        _movieRepository = movieRepository;
        _context = context;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);

        if (movie == null)
        {
            throw new MovieNotFoundException(request.Id);
        }
        
        _movieRepository.Delete(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}