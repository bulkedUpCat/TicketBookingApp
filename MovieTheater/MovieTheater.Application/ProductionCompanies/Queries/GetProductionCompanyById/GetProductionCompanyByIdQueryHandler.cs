using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.ProductionCompany;

namespace MovieTheater.Application.ProductionCompanies.Queries.GetProductionCompanyById;

public class GetProductionCompanyByIdQueryHandler: IRequestHandler<GetProductionCompanyByIdQuery, ProductionCompanyModel>
{
    private readonly IProductionCompanyRepository _productionCompanyRepository;
    private readonly IMapper _mapper;
    
    public GetProductionCompanyByIdQueryHandler(
        IProductionCompanyRepository productionCompanyRepository, 
        IMapper mapper)
    {
        _productionCompanyRepository = productionCompanyRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductionCompanyModel> Handle(GetProductionCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var productionCompany = await _productionCompanyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (productionCompany == null)
        {
            throw new ProductionCompanyNotFoundException(request.Id);
        }

        return _mapper.Map<ProductionCompanyModel>(productionCompany);
    }
}