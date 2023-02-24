using AutoMapper;
using MediatR;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Application.Shared.ProductionCountry;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.ProductionCountries.Commands.CreateProductionCountry;

public class CreateProductionCountryCommandHandler: IRequestHandler<CreateProductionCountryCommand, ProductionCountryModel>
{
    private readonly IProductionCountryRepository _productionCountryRepository;
    private readonly IMovieTheaterDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductionCountryCommandHandler(
        IProductionCountryRepository productionCountryRepository, 
        IMovieTheaterDbContext context, 
        IMapper mapper)
    {
        _productionCountryRepository = productionCountryRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductionCountryModel> Handle(CreateProductionCountryCommand request, CancellationToken cancellationToken)
    {
        var country = _mapper.Map<ProductionCountry>(request);
        
        await _productionCountryRepository.CreateAsync(country, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductionCountryModel>(country);
    }
}