using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.ProductionCompany;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.ProductionCompanies.Commands.CreateProductionCompany;

public class CreateProductionCompanyCommandHandler: IRequestHandler<CreateProductionCompanyCommand, ProductionCompanyModel>
{
    private readonly IProductionCompanyRepository _productionCompanyRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;
    
    public CreateProductionCompanyCommandHandler(
        IProductionCompanyRepository productionCompanyRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _productionCompanyRepository = productionCompanyRepository;
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ProductionCompanyModel> Handle(CreateProductionCompanyCommand request, CancellationToken cancellationToken)
    {
        var productionCompany = _mapper.Map<ProductionCompany>(request);
        
        await _productionCompanyRepository.CreateAsync(productionCompany, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductionCompanyModel>(productionCompany);
    }
}