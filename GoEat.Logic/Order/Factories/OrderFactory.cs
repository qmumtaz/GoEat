using GoEat.Logic.Order.Services;
using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Order.Factories;

public class OrderFactory : IOrderFactory
{
    private readonly IDeliveryCalculator _deliveryCalculator;

    public OrderFactory(IDeliveryCalculator deliveryCalculator)
    {
        _deliveryCalculator = deliveryCalculator;
    }

    public Order CreateOrder()
    {
        var order = new Order();
        order.AddOrderId(Guid.NewGuid());
        return order;
    }

    public OrderItem CreateOrderItem(Guid id, string name, decimal price, string description, int quantity)
    {
        var orderItem = new OrderItem(new Id(id), name, new Price(price) , description, new Quantity(quantity));

        return orderItem;
    }

    //TODO: Fix this
    public List<OrderItem> CreateOrderItems()
    {
        var items = new List<OrderItem>
        {
             new OrderItem(new Id(new Guid()), "" , new Price() , "" , new Quantity()),
        };

        return items;
    }
}

