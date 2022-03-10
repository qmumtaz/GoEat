using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Order.Services;

public class DelieveryCalculator : IDeliveryCalculator
{
    public (Price DeliveryPrice, string? message) CalculateDeliveryPrice(Order order, Price MinimumOrderPrice)
    {
        decimal DeliveryPrice = 0.00M;
        var message = "";

        if (order.SubTotal >= MinimumOrderPrice.Value && order.SubTotal < 30.00M)
        {
            DeliveryPrice = 2.50M;
        }

        if (order.SubTotal > 30.00m)
        {
            DeliveryPrice = 0.00M;
        }

        if (order.SubTotal < 10.00M)
        {
            DeliveryPrice = 5.00M;
            message = $"Minimum order must be over {MinimumOrderPrice}";
        }

        return (new Price(DeliveryPrice), message);
    }
}
