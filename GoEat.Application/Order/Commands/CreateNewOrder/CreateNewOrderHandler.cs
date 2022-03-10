using GoEat.Application.Order.Commands;
using GoEat.Infrastructure.Context;
using GoEat.Logic.Order.Factories;
using GoEat.Logic.Order.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace GoEat.Application.Order.Handlers;

public class CreateNewOrderHandler : IRequestHandler<CreateNewOrder, Guid>
{
    private readonly IOrderFactory _factory;
    private readonly OrderContext _order;
    private readonly IMemoryCache _cache;

    public CreateNewOrderHandler(
        IOrderFactory factory,
        OrderContext order,
        IMemoryCache cache)
    {
        _factory = factory;
        _order = order;
        _cache = cache;
    }

    public async Task<Guid> Handle(CreateNewOrder request, CancellationToken cancellationToken)
    {
        // Create a new ShoppingBasket/Order
        //var shoppingBasket = _factory.Create();
        // Save order in the database 
        // return id of the order
        //var id =  shoppingBasket.Order.Id;
        // return shoppingBasket.Order.Id;
        //return id;

        var createorder = _factory.CreateOrder();

        _cache.Set((object)createorder.Id.Value, createorder);

        return createorder.Id.Value;       
    }
}
