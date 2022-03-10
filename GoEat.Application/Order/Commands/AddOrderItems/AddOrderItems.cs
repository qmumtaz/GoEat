using MediatR;

namespace GoEat.Application.Order.Commands;

public class AddOrderItems :  IRequest
{
    public Guid OrderId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public Guid OrderId { get; set; }
    public Guid OrderItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }

}
