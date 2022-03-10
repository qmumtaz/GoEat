namespace GoEat.Logic.Order.ValueObjects;

//TODO: add calction to the disocunt class so it remains flexible
public record class Discount
{
    public virtual string Code { get; set; }
    public virtual decimal PercentageOff { get; set; }

    public virtual decimal CalcualteDiscount(decimal subtotal)
    {
        return subtotal * PercentageOff;
    }
}
