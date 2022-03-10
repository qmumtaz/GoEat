namespace GoEat.Logic.Order.ValueObjects
{
    public record NullDiscount : Discount
    {
        override public string Code { get; set; } = string.Empty;
        override public decimal PercentageOff { get; set; } = 0.00M;

        public override decimal CalcualteDiscount(decimal subtotal)
        {
            return 0.00M;
        }
    }
}
