using MediatR;
using MovieTheater.Application.Shared.ProductionCompany;

namespace MovieTheater.Application.ProductionCompanies.Queries.GetAllProductionCompanies;

public class GetAllProductionCompaniesQuery: IRequest<IEnumerable<ProductionCompanyModel>>
{
    
}