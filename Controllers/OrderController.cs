using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationCrudWithMediatr.Commands;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [ProducesResponseType(typeof(ProductModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> CreateOrder([FromBody] CreateProductCommand createProductModel)
    {
        try
        {
            var order = await _mediator.Send<ProductModel>(createProductModel);
            return Ok(order);

        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors.ToString());
        }
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetOrders()
    {
        
    }
}