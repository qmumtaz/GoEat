using FluentAssertions;
using GoEat.Logic.Order.Exceptions;
using GoEat.Logic.Order.ValueObjects;
using NUnit.Framework;

namespace GoEat.UnitTests.ValueObjects;

[TestFixture]
public class PriceTest
{
    [Test]
    public void Price_WithNegativeValue_ThrowException()
    {
        Assert.Throws<PriceCannotBeNegativeException>(() => new Price(-10.00M));
    }

    [Test]
    public void Price_ConvertToString_ReturnsStringValueWithCurrencySymbol()
    {
        var price = new Price(10.00M);
        var result = price.ToString();

        result.Should().Be("£10.00");
    }

    [Test]
    public void Price_WithAPositiveValue_ReturnsPositiveValue()
    {
        var result = new Price(10.00M);

        result.Value.Should().Be(10.00M);
    }
}
