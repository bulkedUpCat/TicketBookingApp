using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetScreeningById;

public class GetScreeningByIdQueryHandler: IRequestHandler<GetScreeningByIdQuery, ScreeningModel>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetScreeningByIdQueryHandler(
        IScreeningRepository screeningRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _screeningRepository = screeningRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<ScreeningModel> Handle(GetScreeningByIdQuery request, CancellationToken cancellationToken)
    {
        var screening = await _screeningRepository.GetByIdAsync(request.Id, cancellationToken);

        if (screening == null)
        {
            throw new ScreeningNotFoundException(request.Id);
        }

        return _mapper.Map<ScreeningModel>(screening);
    }
}