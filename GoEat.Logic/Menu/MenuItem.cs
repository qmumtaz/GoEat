using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Menu;

public class MenuItem
{
    public Id Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }

    public Id CategoryId { get; set; }

    public Category Category { get; set; }
}
