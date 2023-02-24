using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Hall;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Halls.Commands.CreateHall;

public class CreateHallCommandHandler: IRequestHandler<CreateHallCommand, HallModel>
{
    private readonly IHallRepository _hallRepository;
    private readonly ISeatRepository _seatRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateHallCommandHandler(
        IHallRepository hallRepository,
        ISeatRepository seatRepository,
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _hallRepository = hallRepository;
        _seatRepository = seatRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<HallModel> Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var hall = _mapper.Map<Hall>(request);

        for (int i = 1; i < request.SeatsNumber + 1; i++)
        {
            var seat = new Seat
            {
                Number = request.SeatsInRow - i % request.SeatsInRow,
                Row = i / request.SeatsInRow + 1
            };

            await _seatRepository.CreateAsync(seat, cancellationToken);
            hall.Seats.Add(seat);
        }

        await _hallRepository.CreateAsync(hall, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<HallModel>(hall);
    }
}