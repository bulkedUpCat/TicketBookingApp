using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.Screenings.Commands.DeleteScreening;

public class DeleteScreeningCommandHandler: IRequestHandler<DeleteScreeningCommand, Unit>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMovieTheaterDbContext _context;

    public DeleteScreeningCommandHandler(
        IScreeningRepository screeningRepository, 
        IMovieTheaterDbContext context)
    {
        _screeningRepository = screeningRepository;
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await _screeningRepository.GetByIdAsync(request.Id, cancellationToken);

        if (screening == null)
        {
            throw new ScreeningNotFoundException(request.Id);
        }

        _screeningRepository.Delete(screening);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}