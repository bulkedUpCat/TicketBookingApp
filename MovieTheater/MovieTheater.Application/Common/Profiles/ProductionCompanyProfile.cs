using AutoMapper;
using MovieTheater.Application.ProductionCompanies.Commands.CreateProductionCompany;
using MovieTheater.Application.Shared.ProductionCompany;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class ProductionCompanyProfile: Profile
{
    public ProductionCompanyProfile()
    {
        CreateMap<ProductionCompany, ProductionCompanyModel>();
        CreateMap<CreateProductionCompanyCommand, ProductionCompany>();
    }
}