using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieTheater.Application.Movies.Queries.GetMovieList;
using MovieTheater.Application.Services;
using MovieTheater.Application.Services.Interfaces;

namespace MovieTheater.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ConfigureMediator(services);
        services.AddScoped<IFunctionService, FunctionService>();
        
        return services;
    }
    
    private static IServiceCollection ConfigureMediator(
        this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetMovieListQuery));

        return services;
    }
}