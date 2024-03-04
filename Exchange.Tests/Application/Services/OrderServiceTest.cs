using Exchange.Application.Interfaces.Persistence;
using Exchange.Application.OrderMatching;
using Exchange.Application.Services;
using Exchange.Application.Services.Orders;
using Exchange.Domain.Entities;
using Exchange.Domain.Enums;
using Moq;

namespace Exchange.Tests.Application.Services;

public class OrderServiceTest
{

    [Fact]
    public void CreateOrder__MultipleTickers__SeparateOrderbooks()
    {
        // Arrange
        Mock<IExchangeRepository> exchangeRepositoryMock = new Mock<IExchangeRepository>();
        // exchangeRepositoryMock.Setups(p=>p.a)

        IOrderEngineService orderEngineService = new OrderEngineService(exchangeRepositoryMock.Object);
        // OrderBook orderBook = new OrderBook();
        // inital orders:
        List<Order> initalBids = new List<Order>(){new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 80,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 70,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "GOOG",
            type = OrderTypes.Limit},
            new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 70,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit}, new Order { account_id = 1,
            order_class = "stock",
            duration = "gtd",
            price = 60,
            quantity = 100,
            quantityFilled = 0,
            recievedTime = new DateTime(),
            side = Side.Buy,
            symbol = "AAPL",
            type = OrderTypes.Limit},};

        // expected orders
        var expectedAAPL = new[]{
            new { Id =  initalBids[0].Id },
            new { Id = initalBids[2].Id },
            new { Id = initalBids[3].Id } ,

        }.ToList();

        var expectedGOOG = new[]{
            new { Id =  initalBids[1].Id },

        }.ToList();


        // Act
        foreach (var order in initalBids)
        {
            orderEngineService.CreateOrder(order);
        }
        //AAPL
        List<Order> orderbookBidsAAPL = orderEngineService.GetOrders(Side.Buy, "AAPL");

        for (int i = 0; i < orderbookBidsAAPL.Count; i++)
        {
            Assert.Equal(expectedAAPL[i].Id, orderbookBidsAAPL[i].Id);

        }

        //GOOG
        List<Order> orderbookBidsGOOG = orderEngineService.GetOrders(Side.Buy, "GOOG");

        for (int i = 0; i < orderbookBidsGOOG.Count; i++)
        {
            Assert.Equal(expectedGOOG[i].Id, orderbookBidsGOOG[i].Id);

        }

    }
}