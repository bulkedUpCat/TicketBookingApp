using MediatR;
using MovieTheater.Application.Shared.ProductionCompany;

namespace MovieTheater.Application.ProductionCompanies.Queries.GetProductionCompanyById;

public class GetProductionCompanyByIdQuery: IRequest<ProductionCompanyModel>
{
    public Guid Id { get; set; }
}