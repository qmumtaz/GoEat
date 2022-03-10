using GoEat.Infrastructure.Repository;
using GoEat.Logic.Order;
using MediatR;

namespace GoEat.Application.Order.Queries.GetAllOrderItems;

public class GetAllOrderItemHandler : IRequestHandler<GetAllOrderItem, List<OrderItem>?>
{
    private readonly IOrderRepository _orderRepisitory;

    public GetAllOrderItemHandler(IOrderRepository orderRepisitory)
    {
        _orderRepisitory = orderRepisitory;
    }

    public async Task<List<OrderItem>?> Handle(GetAllOrderItem request, CancellationToken cancellationToken)
    {
        var orderItems = await _orderRepisitory.GetAllOrderItems(new Logic.Order.ValueObjects.Id(request.Id));

        if (orderItems == null)
        {
            return null;
        }

        return orderItems;
    }
}
