

using GoEat.Logic;
using GoEat.Logic.Services;
using System.Text.Json;

var basket = new ShoppingBasket(
    new GoEat.Logic.ValueObjects.Price(10M),
    new DiscountService(), new DelieveryCalculator());


var json = JsonSerializer.Serialize(basket.Order);

//Store --> Cache

// Getfrom store var json = GetById(id)
var obj = JsonSerializer.Deserialize<Order>(json);

//var factory = Factory.ShoppingBasketFactory();
//var basket = factory.CreateShoppingBasket();

////basket.AddDiscount(new Discount() { Code = "Eid", PercentageOff = 0.1M });

//basket.AddOrderItems(new List<OrderItem>()
//{
//    new(Guid.NewGuid(), "Cheese Burger", 10.00M, "100% Beef")
//});


//var  total = basket.Total;



Console.ReadKey();
