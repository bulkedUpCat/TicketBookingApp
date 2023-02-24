using MediatR;
using MovieTheater.Application.Shared.ProductionCountry;

namespace MovieTheater.Application.ProductionCountries.Queries.GetAllProductionCountries;

public class GetAllProductionCountriesQuery: IRequest<IEnumerable<ProductionCountryModel>>
{
    
}