using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;
using MediatR;

namespace GoEat.Application.Order.Queries.GetOrderItem;

public class GetOrderItemHandler : IRequestHandler<GetOrderItem, OrderItem?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderItemHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderItem?> Handle(GetOrderItem request, CancellationToken cancellationToken)
    {
        var getOrderItem = await _orderRepository.GetOrderItem(new Id(request.Id));

        return getOrderItem ?? null;
    }
}
