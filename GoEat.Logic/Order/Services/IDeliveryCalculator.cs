using GoEat.Logic.Order.ValueObjects;

namespace GoEat.Logic.Order.Services;

public interface IDeliveryCalculator
{
    public (Price DeliveryPrice, string? message) CalculateDeliveryPrice(Order order, Price MinimumOrderPrice);
}
