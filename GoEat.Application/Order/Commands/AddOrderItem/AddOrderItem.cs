using MediatR;

namespace GoEat.Application.Order.AddOrderItem;

public class AddOrderItem : IRequest<decimal>
{
    public Guid OrderId { get; set; }

    public Guid OrderItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
