using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Order;

public class Order
{
    public Id Id { get; set; }

    public List<OrderItem> Items { get; set; }

    private Discount Discount = new NullDiscount();


    public Order()
    {
        Items = new List<OrderItem>();        
    }

    public void AddOrderId(Guid id) => Id = new Id(id);

    public decimal Total(Price delivery) =>
        Math.Round(SubTotal + delivery.Value - Discount.CalcualteDiscount(SubTotal), 2);

    public decimal SubTotal =>
        Items.Select(x => x.Price.Value * x.Quantity).Sum();

    public int Count =>
        Items.Sum(x => x.Quantity);

    public List<OrderItem> GetAllOrderItems => Items;

    public void AddDiscount(Discount discount)
    {
        Discount = discount;
    }

    public void RemoveDiscount(NullDiscount discount)
    {
        Discount = discount;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        if (Items.Contains(orderItem))
        {
            orderItem.AddQuantity(1);
        }

        Items.Add(orderItem);
    }

    public void AddOrderItems(List<OrderItem> orderItems)
    {
        if (orderItems != null && orderItems.Count > 0)
        {
            foreach (var item in orderItems)
            {
                AddOrderItem(item);
            }
        }
    }

    public void RemoveOrderItem(Guid id)
    {
        var orderItem = FindOrderItem(id);

        if (orderItem is not null)
        {
            if (orderItem?.Quantity > 1)
            {
                orderItem.RemoveQuantity(1);
            }
            else if (orderItem?.Quantity == 1)
            {
                Items.Remove(orderItem);
            }
        }
    }

    public void DeleteItem(Guid id)
    {
        var orderItem = FindOrderItem(id);

        if (orderItem is not null)
        {
            Items.Remove(orderItem);
        }
    }

    public void RemoveAllOrderItems() =>
        Items.RemoveRange(0, Items.Count);

    public OrderItem? FindOrderItem(Guid id) =>
        Items.FirstOrDefault((Func<OrderItem, bool>)(x => x.Id.Value == id));
}
