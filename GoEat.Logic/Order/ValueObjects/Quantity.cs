namespace GoEat.Logic.Order.ValueObjects;

public record class Quantity
{
    public int Value { get; set; }

    public Quantity(int value = 1)
    {
        if (value < 1)
        {
            throw new Exception();
        }

        Value = value;
    }

    public int Count => Value;

    public void AddQuantity(int quantity)
    {
        Value += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        var q = Value - quantity;

        if (q < 1)
        {
            Value = 1;
        }
        else
        {
            Value -= quantity;
        }
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity > 0)
        {
            Value = quantity;
        }       
    }

}
