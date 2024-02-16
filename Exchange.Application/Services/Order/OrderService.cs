
using Exchange.Application.Interfaces.Persistence;
using Exchange.Application.Services.Order;

namespace Exchange.Application.Services;

public class OrderService : IOrderService
{
    private readonly IExchangeRepository _exchangeRepository;
    public OrderService(IExchangeRepository exchangeRepository)
    {
        _exchangeRepository = exchangeRepository;
    }

    public void CreateOrder()
    {
        Console.WriteLine("we are in the service!!!");
        //_exchangeRepository.CreateOrder(Order{});

    }
}