using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Infrastructure.Repository;

public interface IOrderRepository
{
    Task AddOrderItem(Id orderId, OrderItem orderItem);
    Task DeleteOrderItem(Id orderId, OrderItem orderItem);
    Task<List<OrderItem>> GetAllOrderItems(Id orderId);
    Task<Order> GetOrder(Id orderId, bool includeOrderItems = false);
    Task<OrderItem> GetOrderItem(Id Orderitemid, bool includeOrderItems = false);
}
