using GoEat.Infrastructure.Context;
using GoEat.Logic.Order.Factories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace GoEat.Application.Order.AddOrderItem;

// TODO: Add concept of menu, and check if each order item exits in the menu before adding it to the order
// TODO: investigate backing field mappings
// TODO: Fix validation (fluent validation not kicking in)

public class AddOrderItemHandler : IRequestHandler<AddOrderItem, decimal>
{
    private readonly IOrderFactory _factory;
    private readonly OrderContext _context;
    private readonly IMemoryCache _cache;

    public AddOrderItemHandler(IOrderFactory factory, OrderContext context, IMemoryCache cache)
    {
        _factory = factory;
        _context = context;
        _cache = cache;
    }

    public async Task<decimal> Handle(AddOrderItem request, CancellationToken cancellationToken)
    {
        // Check if order item exists: request.OrderId
        //var id = new Id(request.OrderId);
        //var order = await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        // Check if order item exists: request.OrderItemId
        //if (order is not null)
        //{
        //    order.AddOrderItem(
        //        new OrderItem(
        //            new Id(request.OrderItemId),
        //            request.Name,
        //            new Price(request.Price),
        //            request.Description,
        //            new Quantity(request.Quantity)));

        //    _context.SaveChanges();
        //}

        //var total = order.Total(new Price());

        var order = _cache.Get<Logic.Order.Order>(request.OrderId);
        order.AddOrderId(request.OrderId);

        var orderItem = _factory.CreateOrderItem(request.OrderItemId, request.Name, request.Price, request.Description, request.Quantity);

        order.AddOrderItem(orderItem);

        _cache.Set<Logic.Order.Order>(request.OrderId, order);

        return 2.5M;
    }
}