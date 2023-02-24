using DinkToPdf;
using DinkToPdf.Contracts;
using MovieTheater.Infrastructure.Utility.Interfaces;

namespace MovieTheater.Infrastructure.Utility;

public class PdfService: IPdfService
{
    private readonly ITemplateGenerator _templateGenerator;
    private readonly IConverter _converter;
    
    public PdfService(
        ITemplateGenerator templateGenerator, 
        IConverter converter)
    {
        _templateGenerator = templateGenerator;
        _converter = converter;
    }

    public async Task<byte[]> GenerateTicketsAsync(Guid reservationId, CancellationToken cancellationToken = default)
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = await _templateGenerator.GetAllTicketsByReservationIdHtmlString(reservationId, cancellationToken),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") }
        };
        var pdf = new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };
        
        var file = _converter.Convert(pdf);
        return file;
    }
    
    public async Task<byte[]> GenerateMoviesReport(CancellationToken cancellationToken = default)
    {
        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "PDF Report"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = await _templateGenerator.GetAllMoviesHtmlString(),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") }
        };
        var pdf = new HtmlToPdfDocument
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };
        
        var file = _converter.Convert(pdf);
        return file;
    }
}