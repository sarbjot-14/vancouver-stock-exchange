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
    public void AddOrder__AddMarketBids__FillBidOrders()
    {
        // Arrange
        OrderBook orderBook = new OrderBook();
        // inital orders:
        List<Order> initalBids = new List<Order>(){new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 10,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 20,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 30,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            quantity = 150,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Sell,
            symbol = "AAPL",
            type = OrderTypes.Market},};

        // expected orders
        var expected = new[]{

            //TODO: check book value
            new { Id = initalBids[1].Id, quantityFilled = 50, bookValue=1000m} ,
            new { Id = initalBids[0].Id, quantityFilled = 0, bookValue = 0m }
        }.ToList();


        // Act
        foreach (var order in initalBids)
        {
            orderBook.AddOrder(order);
        }

        List<Order> orderbookBids = orderBook.GetOrders(Side.Buy);

        for (int i = 0; i < orderbookBids.Count; i++)
        {
            Assert.Equal(expected[i].Id, orderbookBids[i].Id);
            Assert.Equal(expected[i].quantityFilled, orderbookBids[i].quantityFilled);
            Assert.Equal(expected[i].bookValue, orderbookBids[i].bookValue);
        }


    }

    [Fact]
    public void AddOrder__AddLimitBids__DecreasingOrderPriceAndChronologicalPriceIdentical()
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
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 120,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 120,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit}, new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 300,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
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

        List<Order> orderbookBids = orderBook.GetOrders(Side.Buy);

        Assert.Equal(expected.Count, orderbookBids.Count);

        for (int i = 0; i < orderbookBids.Count; i++)
        {
            Assert.Equal(expected[i].Id, orderbookBids[i].Id);
            Assert.Equal(expected[i].price, orderbookBids[i].price);
        }


    }
    [Fact]
    public void AddOrder__AddLimitAsks__IncreasingOrderPriceAndChronologicalPriceIdentical()
    {
        // Arrange
        OrderBook orderBook = new OrderBook();
        // inital orders:
        List<Order> initalBids = new List<Order>(){new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 80,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Sell,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 60,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Sell,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 70,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Sell,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 70,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Sell,
            symbol = "AAPL",
            type = OrderTypes.Limit},};

        // expected orders
        var expected = new[]{
            new { Id = initalBids[1].Id, price = 60 },
            new { Id = initalBids[2].Id, price = 70 },
            new { Id = initalBids[3].Id, price = 70 } ,
            new { Id =  initalBids[0].Id, price = 80 },

        }.ToList();


        // Act
        foreach (var order in initalBids)
        {
            //Console.WriteLine($"next is {order.price}");
            orderBook.AddOrder(order);
        }

        List<Order> orderbookOrders = orderBook.GetOrders(Side.Sell);

        Assert.Equal(expected.Count, orderbookOrders.Count);

        for (int i = 0; i < orderbookOrders.Count; i++)
        {
            Assert.Equal(expected[i].Id, orderbookOrders[i].Id);
            Assert.Equal(expected[i].price, orderbookOrders[i].price);
        }


    }


}