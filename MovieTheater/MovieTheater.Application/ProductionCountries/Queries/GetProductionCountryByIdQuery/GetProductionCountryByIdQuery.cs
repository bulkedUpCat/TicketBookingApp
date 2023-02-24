using MediatR;
using MovieTheater.Application.Shared.ProductionCountry;

namespace MovieTheater.Application.ProductionCountries.Queries.GetProductionCountryByIdQuery;

public class GetProductionCountryByIdQuery: IRequest<ProductionCountryModel>
{
    public Guid Id { get; set; }
}