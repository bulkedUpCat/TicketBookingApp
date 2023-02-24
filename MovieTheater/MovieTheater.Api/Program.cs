using System.Text.Json.Serialization;
using DinkToPdf;
using DinkToPdf.Contracts;
using MovieTheater.Api.Extensions;
using MovieTheater.Api.Middleware;
using MovieTheater.Api.Services;
using MovieTheater.Application.Extensions;
using MovieTheater.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

/*builder.Host.ConfigureWebJobs(b =>
{
    b.AddAzureStorageCoreServices();
    b.AddTimers();
});*/

/*var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();*/

builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureOptions(builder.Configuration);
builder.Services.ConfigureHttpContextAccessor();
builder.Services.ConfigureConverter();
builder.Services.ConfigureCors();

builder.Services.ConfigureAutoMapper();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<MovieMicroservice>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();