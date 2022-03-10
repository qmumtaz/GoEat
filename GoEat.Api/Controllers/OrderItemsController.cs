using GoEat.Application.Order.AddOrderItem;
using GoEat.Application.Order.Queries.GetAllOrderItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoEat.Api.Controllers;

[Route("api/order/{orderId}/orderItems")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IMediator mediator;

    public OrderItemsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrderItems(Guid orderId, GetAllOrderItem getAllOrderItems)
    {
       var getall = await mediator.Send(getAllOrderItems);

        return Ok(getall);  
    }


    [HttpPost]
    public async Task<IActionResult> AddOrderItems(Guid orderId, List<AddOrderItem> orderItem)
    {
        foreach (var item in orderItem)
        {
            item.OrderId = orderId;
        }

        var a = await mediator.Send(orderItem);

        return Ok(a);
    }
}
