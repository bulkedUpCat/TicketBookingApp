using AutoMapper;
using MovieTheater.Application.ProductionCountries.Commands.CreateProductionCountry;
using MovieTheater.Application.Shared.ProductionCountry;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class ProductionCountryProfile: Profile
{
    public ProductionCountryProfile()
    {
        CreateMap<ProductionCountry, ProductionCountryModel>();
        CreateMap<CreateProductionCountryCommand, ProductionCountry>();
    }
}