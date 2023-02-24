using System.Security.Claims;
using Flurl.Http;
using Hangfire.Dashboard.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieTheater.Infrastructure.Utility.Interfaces;
using MovieTheater.Infrastructure.Utility.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Utility;

public class EmailService: IEmailService
{
    private readonly LogicalAppUrlSettings _config;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmailService(
        IOptions<LogicalAppUrlSettings> config,
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _config = config.Value;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task SendMoviesReportAsync(string to, CancellationToken cancellationToken)
    {
        var subject = "Movies Report";

        var link = "https://localhost:7159/api/reports/movies";
        var body = "Hello! You've requested a list of available movies in our cinema. " +
                   $"Click this link: {link}. " +
                   "Please ignore this email if it wasn't you.";

        var url = _config.Url;

        var emailModel = new SendEmailModel
        {
            To = to,
            Subject = subject,
            Body = body
        };

        _ = await url
            .PostJsonAsync(emailModel, cancellationToken: cancellationToken);
    }

    public async Task SendTicketsReportAsync(string to, Guid reservationId, CancellationToken cancellationToken)
    {
        var subject = "Tickets";

        var link = $"https://localhost:7159/api/reports/reservations/{reservationId}";
        var body = "Hello! You've requested the tickets. " +
                   $"Click this link: {link}. " +
                   "Please ignore this email if it wasn't you.";

        var url = _config.Url;

        var emailModel = new SendEmailModel
        {
            To = to,
            Subject = subject,
            Body = body
        };

        _ = await url
            .PostJsonAsync(emailModel, cancellationToken: cancellationToken);
    }
}