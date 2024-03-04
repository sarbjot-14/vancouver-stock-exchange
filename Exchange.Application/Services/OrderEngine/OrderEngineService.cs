
using Exchange.Application.Interfaces.Persistence;
using Exchange.Application.Services.Orders;
using Exchange.Application.OrderMatching;
using Exchange.Domain.Entities;

namespace Exchange.Application.Services;

public class OrderEngineService : IOrderEngineService
{
    private readonly IExchangeRepository _exchangeRepository;
    //OrderBook orderBook;

    private Dictionary<string, OrderBook> _orderbooks = new Dictionary<string, OrderBook>();
    public OrderEngineService(IExchangeRepository exchangeRepository)
    {
        _exchangeRepository = exchangeRepository;
        //orderBook = new OrderBook();
    }

    public void CreateOrder(Order order)
    {
        OrderBook orderBook;
        if (_orderbooks.ContainsKey(order.symbol))
        {
            orderBook = _orderbooks[order.symbol];
            orderBook.AddOrder(order);
        }
        else
        {

            orderBook = new OrderBook();
            orderBook.AddOrder(order);
            _orderbooks.Add(order.symbol, orderBook);

        }

    }

    public List<Order> GetOrders(Side side, string ticker)
    {
        if (_orderbooks.ContainsKey(ticker))
        {
            return _orderbooks[ticker].GetOrders(side);
        }
        else
        {
            throw new Exception("symbol does not exist");
        }

    }


}