using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Halls.Commands.DeleteHall;

public class DeleteHallCommandHandler: IRequestHandler<DeleteHallCommand, Unit>
{
    private readonly IHallRepository _hallRepository;
    private readonly IMovieTheaterDbContext _context;

    public DeleteHallCommandHandler(
        IHallRepository hallRepository, 
        IMovieTheaterDbContext context)
    {
        _hallRepository = hallRepository;
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await _hallRepository.GetByIdAsync(request.Id, cancellationToken);

        if (hall == null)
        {
            throw new HallNotFoundException(request.Id);
        }
        
        _hallRepository.Delete(hall);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}