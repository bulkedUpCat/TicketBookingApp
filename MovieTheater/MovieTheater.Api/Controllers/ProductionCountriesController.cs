using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.ProductionCompanies.Commands.CreateProductionCompany;
using MovieTheater.Application.ProductionCompanies.Queries.GetProductionCompanyById;
using MovieTheater.Application.ProductionCountries.Commands.CreateProductionCountry;
using MovieTheater.Application.ProductionCountries.Queries.GetAllProductionCountries;
using MovieTheater.Application.ProductionCountries.Queries.GetProductionCountryByIdQuery;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/productionCountries")]
public class ProductionCountriesController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProductionCountriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllProductionCountriesQuery(), cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetProductionCountryByIdQuery() { Id = id }, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductionCountryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}