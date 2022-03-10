using GoEat.Application.Order.AddOrderItem;
using GoEat.Application.Order.Commands.DeleteOrderItem;
using GoEat.Application.Order.Commands.UpdateOrderItem;
using GoEat.Application.Order.Queries.GetOrderItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoEat.Api.Controllers;

[Route("api/order/{orderId}/orderItem")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{orderItemId}")]
    public async Task<IActionResult> GetOrderItem(Guid orderitemId, GetOrderItem getOrderItem)
    {
        getOrderItem.Id = orderitemId;

        var a =  _mediator.Send(orderitemId);

        return Ok(a);   
    }

    [HttpPut("{orderItemId}")]
    public async Task<IActionResult> UpdateOrderItemQuanity(Guid orderitemId, UpdateOrderQuantity updateQuantity)
    {
        updateQuantity.Id = orderitemId;

        var a = await _mediator.Send(updateQuantity);

        return Ok();
    }


    [HttpPost]
    public async Task<IActionResult> AddOrderItem(Guid orderId, AddOrderItem orderItem)
    {
        orderItem.OrderId = orderId;

        var a = await _mediator.Send(orderItem);

        return Ok();
    }


    [HttpDelete("{orderItemId}")]
    public async Task<IActionResult> DeleteOrderItemAsync(Guid orderId, DeleteOrderItem orderItem)
    {
        orderItem.Id = orderId; 

        var a = await _mediator.Send(orderItem);

        return Ok();
    }
}
