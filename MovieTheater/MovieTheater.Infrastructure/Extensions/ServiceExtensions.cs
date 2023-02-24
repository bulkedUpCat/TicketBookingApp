using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;
using MovieTheater.Infrastructure.Auth.JWT;
using MovieTheater.Infrastructure.Auth.Services;
using MovieTheater.Infrastructure.Auth.Services.Interfaces;
using MovieTheater.Infrastructure.Data.Contexts;
using MovieTheater.Infrastructure.Data.Repositories;
using MovieTheater.Infrastructure.Utility;
using MovieTheater.Infrastructure.Utility.Interfaces;

namespace MovieTheater.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IMovieTheaterDbContext, MovieTheaterDbContext>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IScreeningRepository, ScreeningRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IReservedSeatRepository, ReservedSeatRepository>();
        services.AddScoped<IProductionCompanyRepository, ProductionCompanyRepository>();
        services.AddScoped<IProductionCountryRepository, ProductionCountryRepository>();
        services.AddScoped<IMovieDirectorRepository, MovieDirectorRepository>();
        services.AddScoped<IMovieLanguageRepository, MovieLanguageRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtHandler, JwtHandler>();
        services.AddScoped<ITemplateGenerator, TemplateGenerator>();
        services.AddScoped<IPdfService, PdfService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IRawQueryService, RawQueryService>();

        services.ConfigureIdentity();
        services.ConfigureAuthentication(config);

        return services;
    }

    private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<MovieTheaterDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("JwtSettings")["Issuer"],
                    ValidAudience = configuration.GetSection("JwtSettings")["Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings")["Key"]))
                };
            });
    }
}