using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetAllScreenings;

public class GetAllScreeningsQueryHandler: IRequestHandler<GetAllScreeningsQuery, IEnumerable<ScreeningModel>>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public GetAllScreeningsQueryHandler(
        IScreeningRepository screeningRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _screeningRepository = screeningRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ScreeningModel>> Handle(GetAllScreeningsQuery request, CancellationToken cancellationToken)
    {
        var screenings = await _screeningRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ScreeningModel>>(screenings);
    }
}