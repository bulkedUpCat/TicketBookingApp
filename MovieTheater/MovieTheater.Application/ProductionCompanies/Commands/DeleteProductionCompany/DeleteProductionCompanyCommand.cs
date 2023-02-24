using MediatR;

namespace MovieTheater.Application.ProductionCompanies.Commands.DeleteProductionCompany;

public class DeleteProductionCompanyCommand: IRequest
{
    public Guid Id { get; set; }   
}