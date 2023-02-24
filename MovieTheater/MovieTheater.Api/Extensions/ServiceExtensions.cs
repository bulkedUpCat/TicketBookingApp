using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Api.Profiles;
using MovieTheater.Infrastructure.Auth.JWT;
using MovieTheater.Infrastructure.Auth.Profiles;
using MovieTheater.Infrastructure.Data.Contexts;
using MovieTheater.Infrastructure.Utility.Models;
using Serilog;

namespace MovieTheater.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDbContext(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<MovieTheaterDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
        });

        return services;
    }

    public static IServiceCollection ConfigureOptions(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.Configure<LogicalAppUrlSettings>(configuration.GetSection("LOGICAL_APP_URL"));
        services.Configure<DatabaseConnection>(configuration.GetSection("ConnectionStrings"));

        return services;
    }
    
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MovieProfile), typeof(AuthProfile), typeof(Application.Common.Profiles.MovieProfile));

        return services;
    }
    
    public static IServiceCollection ConfigureHttpContextAccessor(
        this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
        return services;
    }

    public static IServiceCollection ConfigureConverter(
        this IServiceCollection services)
    {
        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        return services;
    }
}