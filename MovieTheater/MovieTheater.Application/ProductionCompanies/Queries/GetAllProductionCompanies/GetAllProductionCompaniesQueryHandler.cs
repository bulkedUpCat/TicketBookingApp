using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.ProductionCompany;

namespace MovieTheater.Application.ProductionCompanies.Queries.GetAllProductionCompanies;

public class GetAllProductionCompaniesQueryHandler: IRequestHandler<GetAllProductionCompaniesQuery, IEnumerable<ProductionCompanyModel>>
{
    private readonly IProductionCompanyRepository _productionCompanyRepository;
    private readonly IMapper _mapper;
    
    public GetAllProductionCompaniesQueryHandler(
        IProductionCompanyRepository productionCompanyRepository, 
        IMapper mapper)
    {
        _productionCompanyRepository = productionCompanyRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductionCompanyModel>> Handle(GetAllProductionCompaniesQuery request, CancellationToken cancellationToken)
    {
        var productionCompanies = await _productionCompanyRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductionCompanyModel>>(productionCompanies);
    }
}