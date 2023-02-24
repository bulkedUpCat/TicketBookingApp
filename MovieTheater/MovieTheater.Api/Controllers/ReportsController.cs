using Microsoft.AspNetCore.Mvc;
using MovieTheater.Api.Models;
using MovieTheater.Infrastructure.Utility.Interfaces;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController: ControllerBase
{
    private readonly IPdfService _pdfService;
    private readonly IEmailService _emailService;

    public ReportsController(
        IPdfService pdfService, 
        IEmailService emailService)
    {
        _pdfService = pdfService;
        _emailService = emailService;
    }
    
    [HttpGet("reservations/{id:guid}")]
    public async Task<IActionResult> CreateTicketsPdf(Guid id, CancellationToken cancellationToken)
    {
        var file = await _pdfService.GenerateTicketsAsync(id, cancellationToken);
        return File(file, "application/pdf");
    }

    [HttpGet("movies")]
    public async Task<IActionResult> CreateMoviesPdf(CancellationToken cancellationToken)
    {
        var file = await _pdfService.GenerateMoviesReport(cancellationToken);
        return File(file, "application/pdf");
    }

    [HttpPost("/api/email/reports/movies")]
    public async Task<IActionResult> SendMoviesReportEmail(SendEmailModel model, CancellationToken cancellationToken)
    {
        await _emailService.SendMoviesReportAsync(model.Email, cancellationToken);
        return Ok();
    }

    [HttpPost("/api/email/reports/reservations/{id:guid}")]
    public async Task<IActionResult> SendTicketsEmail(Guid id, SendEmailModel model, CancellationToken cancellationToken)
    {
        await _emailService.SendTicketsReportAsync(model.Email, id, cancellationToken);
        return Ok();
    }
}