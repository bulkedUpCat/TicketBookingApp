using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.ProductionCountry;

namespace MovieTheater.Application.ProductionCountries.Queries.GetProductionCountryByIdQuery;

public class GetProductionCountryByIdQueryHandler: IRequestHandler<GetProductionCountryByIdQuery, ProductionCountryModel>
{
    private readonly IProductionCountryRepository _productionCountryRepository;
    private readonly IMapper _mapper;

    public GetProductionCountryByIdQueryHandler(
        IProductionCountryRepository productionCountryRepository, 
        IMapper mapper)
    {
        _productionCountryRepository = productionCountryRepository;
        _mapper = mapper;
    }

    public async Task<ProductionCountryModel> Handle(GetProductionCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var productionCountry = await _productionCountryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (productionCountry == null)
        {
            throw new ProductionCountryNotFoundException(request.Id);
        }

        return _mapper.Map<ProductionCountryModel>(productionCountry);
    }
}