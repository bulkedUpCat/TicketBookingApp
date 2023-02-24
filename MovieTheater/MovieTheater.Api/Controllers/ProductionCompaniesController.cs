using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.ProductionCompanies.Commands.CreateProductionCompany;
using MovieTheater.Application.ProductionCompanies.Commands.DeleteProductionCompany;
using MovieTheater.Application.ProductionCompanies.Queries.GetAllProductionCompanies;
using MovieTheater.Application.ProductionCompanies.Queries.GetProductionCompanyById;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/productionCompanies")]
public class ProductionCompaniesController: ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProductionCompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllProductionCompaniesQuery(), cancellationToken));
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetProductionCompanyByIdQuery() { Id = id }, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductionCompanyCommand request, CancellationToken cancellationToken)
    {
        var productionCompany = await _mediator.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = productionCompany.Id }, productionCompany);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductionCompanyCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}