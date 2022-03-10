using GoEat.Infrastructure.Context;
using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GoEat.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context;
    }

    public async Task<Order> GetOrder(Id orderId, bool includeOrderItems = false)
    {
        if (includeOrderItems)
        {
            return await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == orderId);
        }

        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
    }

    public async Task<OrderItem> GetOrderItem(Id Orderitemid, bool includeOrderItems = false)
    {
        var orderItem = await _context.OrderItems.FirstOrDefaultAsync(y => y.Id == Orderitemid);

        return orderItem;
    }

    public async Task AddOrderItem(Id orderId, OrderItem orderItem)
    {
        var order = await GetOrder(orderId, true);

        if (order is not null)
        {
            order.AddOrderItem(orderItem);

            SaveChanges();
        }
    }

    public async Task DeleteOrderItem(Id orderId, OrderItem orderItem)
    {
        var order = await GetOrder(orderId, true);
        if (order is not null)
        {
            _context.OrderItems.Remove(orderItem);

           SaveChanges();
        }
    }

    public async Task<List<OrderItem>> GetAllOrderItems(Id orderId)
    {
        var orderItems = await _context.OrderItems
             .Where(x => x.OrderId == orderId)
             .ToListAsync();

        return orderItems;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}