using GoEat.Logic.Order.Exceptions;

namespace GoEat.Logic.Order.ValueObjects
{
    //TODO: add currency
    public record class Price
    {
        public decimal Value { get; }

        public Price(decimal value = 0.00M)
        {
            if (value < 0.00M)
            {
                throw new PriceCannotBeNegativeException();
            }

            Value = Math.Round(value, 2);
        }

        public override string ToString()
        {
            return string.Format(Currency.CultureInfo, "{0:C}", Value);
        }
    }
}