using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Exchange.Application.OrderMatching;
using Exchange.Domain.Entities;
using Exchange.Domain.Enums;
namespace Exchange.Tests.Application.OrderBookTest;

// The name of your test should consist of three parts:
// The name of the method being tested.
// The scenario under which it's being tested.
// The expected behavior when the scenario is invoked.

public class OrderBookTest
{

    [Fact]
    public void AddOrder__AddLimitBids()
    {
        // Arrange
        OrderBook orderBook = new OrderBook();
        // inital orders:
        List<Order> initalBids = new List<Order>(){new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 200,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = "buy",
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 120,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = "buy",
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 120,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = "buy",
            symbol = "AAPL",
            type = OrderTypes.Limit}, new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 300,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = "buy",
            symbol = "AAPL",
            type = OrderTypes.Limit},};
            
        // expected orders
        var expected = new[]{
            new { Id =  initalBids[3].Id, price = 300 },
            new { Id = initalBids[0].Id, price = 200 },
            new { Id = initalBids[1].Id, price = 120 } ,
            new { Id = initalBids[2].Id, price = 120 }
        }.ToList();


        // Act
        foreach (var order in initalBids)
        {
            //Console.WriteLine($"next is {order.Id}");
            orderBook.AddOrder(order);
        }

        List<Order> orderbookBids = orderBook.GetBids();

        Assert.Equal(expected.Count, orderbookBids.Count);

        for (int i = 0; i < orderbookBids.Count; i++)
        {
            Assert.Equal(expected[i].Id, orderbookBids[i].Id);
            Assert.Equal(expected[i].price, orderbookBids[i].price);
        }


    }

    
}