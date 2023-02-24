using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.Screening;

namespace MovieTheater.Application.Screenings.Queries.GetScreeningsByHallId;

public class GetScreeningsByHallIdQueryHandler: IRequestHandler<GetScreeningsByHallIdQuery, IEnumerable<ScreeningModel>>
{
    private readonly IScreeningRepository _screeningRepository;
    private readonly IMapper _mapper;

    public GetScreeningsByHallIdQueryHandler(
        IScreeningRepository screeningRepository,
        IMapper mapper)
    {
        _screeningRepository = screeningRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ScreeningModel>> Handle(GetScreeningsByHallIdQuery request, CancellationToken cancellationToken)
    {
        var screenings = await _screeningRepository.GetAllByHallId(request.HallId, cancellationToken);
        return _mapper.Map<IEnumerable<ScreeningModel>>(screenings);
    }
}