using GoEat.Logic.Order;
using MediatR;

namespace GoEat.Application.Order.Queries.GetAllOrderItems;

public class GetAllOrderItem : IRequest<List<OrderItem>?>
{
    public Guid Id { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
