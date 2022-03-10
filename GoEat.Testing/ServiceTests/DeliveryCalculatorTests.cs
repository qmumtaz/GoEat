using Bogus;
using FluentAssertions;
using GoEat.Logic.Order;
using GoEat.Logic.Order.Services;
using GoEat.Logic.Order.ValueObjects;
using NUnit.Framework;
using System;

namespace GoEat.UnitTests.ServiceTests;

[TestFixture]
public class DeliveryCalculatorTests
{
    [Test]
    [TestCase(12.00, 2.50)]
    [TestCase(42.00, 0.00)]
    [TestCase(2.00, 5.00)]
    public void CalculateDeliveryPrice_OrderPriceGreaterThanMinimumOrderPrice_And_LessThan30Pound_ReturnsDeliverPriceAt2_50_And_OrderCanBeDelievered(
        decimal price, decimal expectedDeliveryPrice)
    {
        // Arrange
        var deliveryCalculator = new DelieveryCalculator();

        var faker = new Faker();
        var orderitem = new OrderItem(new Id(Guid.NewGuid()), faker.Lorem.Word(), new Price(price), faker.Lorem.Sentences(), new Quantity());

        var order = new Order();
        order.AddOrderItem(orderitem);

        // Act
        (Price DeliveryPrice, _) = deliveryCalculator.CalculateDeliveryPrice(order, new Price(price));

        // Assert
        // Assert.That(DeliveryPrice.Value == expectedDeliveryPrice);
        DeliveryPrice.Value.Should().Be(expectedDeliveryPrice);
    }
}
