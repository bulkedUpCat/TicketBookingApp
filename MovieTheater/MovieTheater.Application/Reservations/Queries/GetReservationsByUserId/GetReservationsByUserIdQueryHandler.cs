using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Reservation;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Reservations.Queries.GetReservationsByUserId;

public class GetReservationsByUserIdQueryHandler: IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<ReservationModel>>
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;
    private readonly IMovieTheaterDbContext _context;
    private readonly UserManager<User> _userManager;

    public GetReservationsByUserIdQueryHandler(
        IReservationRepository reservationRepository, 
        IScreeningRepository screeningRepository,
        IMapper mapper, 
        IMovieTheaterDbContext context, 
        UserManager<User> userManager)
    {
        _reservationRepository = reservationRepository;
        _screeningRepository = screeningRepository;
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<IEnumerable<ReservationModel>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var _ = await _userManager.FindByIdAsync(request.UserId)
                   ?? throw new UserNotFoundException(new Guid(request.UserId));

        var reservations = await _reservationRepository.GetAllByUserId(request.UserId, cancellationToken);

        return _mapper.Map<IEnumerable<ReservationModel>>(reservations);
    }
}