using GoEat.Application.Order.Commands;
using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order.Factories;
using GoEat.Logic.Order.ValueObjects;
using MediatR;

namespace GoEat.Application.Order.Handlers;

public class AddOrderItemsHandler : IRequestHandler<AddOrderItems>
{
    private readonly IOrderFactory _factory;
    private readonly IOrderRepository _repository;

    public AddOrderItemsHandler(IOrderFactory factory, IOrderRepository repository)
    {
        _factory = factory;
        _repository = repository;
    }

    public async Task<Unit> Handle(AddOrderItems request, CancellationToken cancellationToken)
    {
        List<Logic.Order.OrderItem> orderItems = new();
        
        foreach (var item in request.OrderItems)
        {
            var orderItem = _factory.CreateOrderItem(item.OrderItemId, item.Name, item.Price, item.Description, item.Quantity);
            orderItems.Add(orderItem);
        }

        foreach (var item in orderItems)
        {
            await _repository.AddOrderItem(new Id(request.OrderId), item);
        }

        return Unit.Value;
    }
}
