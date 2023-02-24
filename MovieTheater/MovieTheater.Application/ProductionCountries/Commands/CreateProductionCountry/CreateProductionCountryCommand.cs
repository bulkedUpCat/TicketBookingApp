using MediatR;
using MovieTheater.Application.Shared.ProductionCountry;

namespace MovieTheater.Application.ProductionCountries.Commands.CreateProductionCountry;

public class CreateProductionCountryCommand: IRequest<ProductionCountryModel>
{
    public string Name { get; set; }
    public int Rank { get; set; }
}