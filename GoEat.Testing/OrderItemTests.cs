using Bogus;
using FluentAssertions;
using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;
using NUnit.Framework;
using System;

namespace GoEat.UnitTests;

// naming convention:
// what you are testing_what happens_what you expect;

[TestFixture]
public class OrderItemTests
{
    private OrderItem _orderItem;

    [SetUp]
    public void SetUp()
    {
        var faker = new Faker();

        var price = new Price(faker.Finance.Amount(1, 20, 2));
        var name = faker.Lorem.Word();
        var description = faker.Lorem.Sentences();

        _orderItem = new OrderItem(new Id(Guid.NewGuid()), name, price, description, new Quantity());
    }

    [Test]
    public void AddQuantity_IncreasingQuanityBy1_ItemQuanityReturn2()
    {
        _orderItem.AddQuantity(1);
    
        _orderItem.Quantity.Should().Be(2);
    }

    [Test]
    public void RemoveQuantity_ItemQuantityis4_Remove1_Returns3()
    {
        _orderItem.AddQuantity(3);
        _orderItem.RemoveQuantity(1);
        
        _orderItem.Quantity.Should().Be(3);
    }

    [Test]
    public void RemoveQauntity_ItemQuantityis4_Remove5_Returns1()
    {
        _orderItem.AddQuantity(3);
        _orderItem.RemoveQuantity(4);

        Assert.That(_orderItem.Quantity == 1);
    }

    [Test]
    public void Quantity_DefaultQauntity_isSetTo1()
    {           
        _orderItem.Quantity.Should().Be(1);
    }
}
