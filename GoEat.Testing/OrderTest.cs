using FluentAssertions;
using GoEat.Logic.Order;
using GoEat.Logic.Order.ValueObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GoEat.UnitTests;


[TestFixture]
public class OrderTest
{
    [Test]

    public void AddOrderItem_WithOneOrderItem_ReturnsNumberOfOrderItems()
    {
        var orderitem = new OrderItem(
            new Id(Guid.NewGuid()), " " ,new Price(10.00M),"Its a burger", new Quantity());
        var order = new Order();
        order.AddOrderItem(orderitem);
        
        order.Count.Should().Be(1);
    }

    [Test]
    public void AddOrderItems_WithOrderItemList_ReturnsNumberOfOrderItems()
    {
        var orderitem = new List<OrderItem> 
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(12.00M), "Tuna pasta", new Quantity())
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
     
        order.Count.Should().Be(2);
    }

    [Test]
    public void RemoveOrderItem()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var id2 = Guid.Parse("7CADFEA4-721E-4A5C-8C20-26455F041B50");

        var orderitem = new List<OrderItem> 
        { 
            new OrderItem(new Id(id1), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(new Id(id2), " ", new Price(12.00M), "Tuna pasta", new Quantity(2))
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
        order.RemoveOrderItem(id2);

        order.Count.Should().Be(2);
    }

    [Test]
    public void RemoveOrderItems_With2OrderItems_Returns0()
    {
        var orderitem = new List<OrderItem> 
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(12.00M), "Tuna pasta", new Quantity())
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
        order.RemoveAllOrderItems();

        order.Count.Should().Be(0);
    }

    [Test]
    public void Count_With5OrderItems_ReturnCountAs5()
    {
        var orderitem = new List<OrderItem>
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(12.00M), "Tuna pasta", new Quantity(2)),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(14.00M), "chicken pasta", new Quantity(2))
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
        order.Count.Should().Be(5);
    }

    [Test]
    public void Count_With4OrderItems_ReturnCountA4()
    {
        var orderitem = new List<OrderItem>
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(12.00M), "Tuna pasta", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(14.00M), "chicken pasta", new Quantity(2))
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
        order.Count.Should().Be(4);
    }

    [Test]
    public void Subtotal_With3OrderItems_ReturnSubTotal()
    {
        var orderitem = new List<OrderItem>
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(8.00M), "Tuna pasta", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(2.00M), "chicken pasta", new Quantity())
        };

        var order = new Order();
        order.AddOrderItems(orderitem);

        order.SubTotal.Should().Be(20.00M);
    }

    [Test]
    public void Subtotal_With3OrderItems_SubtotalShouldbeEqualtoOrderAmount()
    {
        var orderitem = new List<OrderItem>
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(8.00M), "Tuna pasta", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(2.00M), "chicken pasta", new Quantity(2))
        };

        var order = new Order();
        order.AddOrderItems(orderitem);

        order.SubTotal.Should().Be(22.00M);
    }

    [Test]
    public void RemoveAllOrderItems()
    {
        var orderitem = new List<OrderItem>
        {
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(10.00M), "Cheese burger", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(8.00M), "Tuna pasta", new Quantity()),
            new OrderItem(
                new Id(Guid.NewGuid()), " ", new Price(2.00M), "chicken pasta", new Quantity())
        };

        var order = new Order();
        order.AddOrderItems(orderitem);
        order.RemoveAllOrderItems();

        Assert.IsTrue(order.Count == 0);
    }

    [Test]

    public void FindOrderItem_ReturnIfOrderItemIdIsEqualtoFindId()
    {
        var id = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var orderitem = new OrderItem(
            new Id(id), "Burger ", new Price(10.00M), "Has cheese in it", new Quantity());
       
        var order = new Order();
        order.AddOrderItem(orderitem);
        
        var find = order.FindOrderItem(id);

        Assert.AreEqual(orderitem.Id, find.Id);
    }

    [Test]

    public void Total_OrderItem_ReturnIsTotalEqaultoOrderAmount()
    { 
        var order = new Order();
        order.AddOrderItem(new OrderItem(new Id(Guid.NewGuid()),"Burger" ,new Price(12.00M),"Cheese with beef",new Quantity(2)));

        Assert.AreEqual(26.00M , order.Total(new Price(2.00M)));
    }

    [Test]

    public void GetAllOrderItem_With2OrderItems_ReturnCountEqaulTo2()
    {
        var order = new Order();
        order.AddOrderItems(new List<OrderItem>{
        new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity()),
        new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity())
         });
      
        Assert.That(order.GetAllOrderItems.Count == 2);    
    }

    [Test]

    public void AddDiscount()
    {
        var order = new Order();

        order.AddOrderItems(new List<OrderItem>
        {
            new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity()),
            new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity())
         });

        var discount = new Discount
        {
            PercentageOff = 0.1M
        };

        order.AddDiscount(discount);

        var result = order.Total(new Price());

        Assert.That(result == 21.60M);
    }

    [Test]
    public void RemoveDiscount()
    {
        var order = new Order();

        order.AddOrderItems(new List<OrderItem>
        {
            new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity()),
            new OrderItem(new Id(Guid.NewGuid()), "Burger", new Price(12.00M), "Cheese with beef", new Quantity())
        });

        order.AddDiscount(new Discount
        {
            PercentageOff = 0.10M
        });

        var withDiscount = order.Total(new Price());

        order.RemoveDiscount(new NullDiscount());

        var withDiscountRemoved = order.Total(new Price());

        Assert.That(withDiscount == 21.60M);
        Assert.That(withDiscountRemoved == 24.00M);
    }

    [Test]
    public void RemoveOrderOrderItem_WithOneOriderItemwithQuantityof2_ReturnOneQuantity()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var order = new Order();
        var orderitem = new OrderItem(new Id(id1), "Burger", new Price(12.00M), "Cheese with beef", new Quantity(2));

        order.AddOrderItem(orderitem);
        order.RemoveOrderItem(id1);

        Assert.That(orderitem.Quantity == 1);
    }

    [Test]
    public void RemoveOrderOrderItem_WithIdThatHasNoOrderItem_ReturnCountEqaulto1()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var id2 = Guid.Parse("7CADFEA4-721E-4A5C-8C20-26455F041B50");
        var orderitem = new OrderItem(new Id(id2), "Burger", new Price(12.00M), "Cheese with beef", new Quantity());
        var order = new Order(); 

        order.AddOrderItem(orderitem);
        order.RemoveOrderItem(id1);

        Assert.That(order.Count == 1);
    }

    [Test]
    public void RemoveOrderOrderItem_WithOneOrderItem_ReturnisNotNull()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");    
        var orderitem = new OrderItem(new Id(id1), "Burger", new Price(12.00M), "Cheese with beef", new Quantity());
        var order = new Order();

        order.AddOrderItem(orderitem);
        order.RemoveOrderItem(id1);

        Assert.IsNotNull(order);
    }

    [Test]
    public void DeleteItem_WithOneOrderItem_ReturnsCountWith0()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var orderitem = new OrderItem(new Id(id1), "Burger", new Price(12.00M), "Cheese with beef", new Quantity());
        var order = new Order();

        order.AddOrderItem(orderitem);
        order.DeleteItem(id1);

        Assert.That(order.Count == 0);
    }

    [Test]
    public void DeleteItem_WIthOneOrderItem_ReturnisNotNull()
    {
        var id1 = Guid.Parse("E6C19B9F-95ED-4CDE-8DEC-006CB2E49CBA");
        var orderitem = new OrderItem(new Id(id1), "Burger", new Price(12.00M), "Cheese with beef", new Quantity());
        var order = new Order();

        order.AddOrderItem(orderitem);
        order.DeleteItem(id1);


        Assert.IsNotNull(order);
    }
}
