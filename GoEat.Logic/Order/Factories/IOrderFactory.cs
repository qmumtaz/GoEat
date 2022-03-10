namespace GoEat.Logic.Order.Factories;

public interface IOrderFactory
{
    Order CreateOrder();
    OrderItem CreateOrderItem(Guid id, string name, decimal price, string description, int quantity);
}

