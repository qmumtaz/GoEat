using GoEat.Application.Order.Commands;
using GoEat.Application.Order.Queries;
using GoEat.Logic.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoEat.Api.Controllers;

// http://localhost:5000/api/order
// http://localhost:5000/api/order/{id}/orderitem

// TODO: add domain events
// TODO: add automatic discount (ex, if a customer has order over £20, they automatcally recieve a 10% discount)

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{orderId}/total")]
    public async Task<IActionResult> GetTotal(Guid orderId)
    {
        if (orderId == Guid.Empty)
        {
            return BadRequest();
        }

        var orderTotal = await _mediator.Send(new GetTotal(orderId));

        if (orderTotal == null)
        {
            return NotFound();
        }

        return Ok(orderTotal);
    }

    [HttpGet("{orderId}/subtotal")]
    public IActionResult GetSubtotal(Guid orderId)
    {

        if (orderId == Guid.Empty)
        {
            return BadRequest();
        }

        var ordersubtotal = await _mediator.Send(new Order().SubTotal);

        if (orderTotal == null)
        {
            return NotFound();
        }

        return Ok(orderTotal);
    }

    [HttpGet("{orderId}/delivery")]
    public IActionResult GetDeliveryPrice(Guid orderId)
    {
        throw new NotImplementedException();
    }

    //TODO: Rate limit this endpoint
    [HttpPost] 
    public async Task<IActionResult> CreateNewOrder()
    { 
        string? ipAddress = HttpContext?.Connection?.RemoteIpAddress?.ToString();

        var id = await _mediator.Send(new CreateNewOrder(1));

        return Ok(id);
    }

    [HttpPost("{orderId}/discount")]
    public IActionResult AddDiscount(Guid orderId)
    {
        throw new NotImplementedException();
    }


    [HttpDelete("{orderId}/discount")]
    public IActionResult DeleteDiscount(Guid orderId)
    {
        throw new NotImplementedException();
    }
}

