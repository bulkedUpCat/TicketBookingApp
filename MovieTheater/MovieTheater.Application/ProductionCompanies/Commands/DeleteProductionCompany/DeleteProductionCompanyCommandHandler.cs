using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Exceptions.NotFoundException;

namespace MovieTheater.Application.ProductionCompanies.Commands.DeleteProductionCompany;

public class DeleteProductionCompanyCommandHandler: IRequestHandler<DeleteProductionCompanyCommand>
{
    private readonly IProductionCompanyRepository _productionCompanyRepository;
    private readonly IMovieTheaterDbContext _context;
    
    public DeleteProductionCompanyCommandHandler(
        IProductionCompanyRepository productionCompanyRepository, 
        IMovieTheaterDbContext context)
    {
        _productionCompanyRepository = productionCompanyRepository;
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteProductionCompanyCommand request, CancellationToken cancellationToken)
    {
        var productionCompany = await _productionCompanyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (productionCompany == null)
        {
            throw new ProductionCompanyNotFoundException(request.Id);
        }

        _productionCompanyRepository.Delete(productionCompany);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}