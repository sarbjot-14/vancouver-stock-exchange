using Exchange.Application.OrderMatching;
using Exchange.Domain.Entities;

namespace Exchange.Tests.Application.OrderMatching;

public class OrderBookTest
{

    [Fact]
    public void AddOrder__AddLimitBids()
    {
        // arrange
        OrderBook orderBook = new OrderBook();

        Order order = new Order { account_id = 1, order_class = "stock", duration = "gtd", price = 100, quantity = 100, quantityFilled = 0, recievedTime = new DateTime(), side = "buy", symbol = "AAPL", type = "limit" };
        // act
        orderBook.AddOrder(order);

        // assert
        List<Order> orderedBids = orderBook.GetBids();

        Assert.Equal(1, 1);

        //Assert.Equal(Comparer.)


    }
}