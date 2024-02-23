
using Exchange.Application.Interfaces.Persistence;
using Exchange.Application.Services.Orders;
using Exchange.Application.OrderMatching;
using Exchange.Domain.Entities;

namespace Exchange.Application.Services;

public class OrderEngineService : IOrderEngineService
{
    private readonly IExchangeRepository _exchangeRepository;
    OrderBook orderBook;
    public OrderEngineService(IExchangeRepository exchangeRepository)
    {
        _exchangeRepository = exchangeRepository;
        orderBook = new OrderBook();
    }

    public void CreateOrder(Order order)
    {

        //_exchangeRepository.CreateOrder(order);
        orderBook.AddOrder(order);

    }


}