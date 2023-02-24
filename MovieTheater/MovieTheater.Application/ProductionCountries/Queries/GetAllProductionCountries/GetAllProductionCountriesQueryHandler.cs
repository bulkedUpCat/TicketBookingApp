using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.ProductionCountry;

namespace MovieTheater.Application.ProductionCountries.Queries.GetAllProductionCountries;

public class GetAllProductionCountriesQueryHandler: IRequestHandler<GetAllProductionCountriesQuery, IEnumerable<ProductionCountryModel>>
{
    private readonly IProductionCountryRepository _productionCountryRepository;
    private readonly IMapper _mapper;

    public GetAllProductionCountriesQueryHandler(
        IProductionCountryRepository productionCountryRepository, 
        IMapper mapper)
    {
        _productionCountryRepository = productionCountryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductionCountryModel>> Handle(GetAllProductionCountriesQuery request, CancellationToken cancellationToken)
    {
        var productionCountries = await _productionCountryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductionCountryModel>>(productionCountries);
    }
}