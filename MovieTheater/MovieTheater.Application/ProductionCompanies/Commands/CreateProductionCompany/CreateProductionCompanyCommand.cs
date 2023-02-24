using MediatR;
using MovieTheater.Application.Shared.ProductionCompany;

namespace MovieTheater.Application.ProductionCompanies.Commands.CreateProductionCompany;

public class CreateProductionCompanyCommand: IRequest<ProductionCompanyModel>
{
    public string Name { get; set; }
    public int Rank { get; set; }
}