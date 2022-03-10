using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Order;

public class OrderItem
{
    public Id Id { get; }
    public string Name { get; }
    public Price Price { get; }
    public string Description { get; }
    public Quantity ItemQuantity { get; set; }
    public Order Order { get; set; }
    public Id OrderId { get; set; }

    private OrderItem()
    {

    }

    public OrderItem(
        Id id,
        string name,
        Price price,
        string description,
        Quantity itemquantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        ItemQuantity = itemquantity;
    }

    public void AddQuantity(int quantity) =>
        ItemQuantity.AddQuantity(quantity);

    public void RemoveQuantity(int quantity) =>
        ItemQuantity.RemoveQuantity(quantity);

    public void UpdateQuantity(int quantity) =>
       ItemQuantity.UpdateQuantity(quantity);

    public int Quantity => ItemQuantity.Count;
}
