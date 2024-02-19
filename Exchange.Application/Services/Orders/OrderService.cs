
using Exchange.Application.Interfaces.Persistence;
using Exchange.Application.Services.Orders;
using Exchange.Domain.Entities;

namespace Exchange.Application.Services;

public class OrderService : IOrderService
{
    private readonly IExchangeRepository _exchangeRepository;
    public OrderService(IExchangeRepository exchangeRepository)
    {
        _exchangeRepository = exchangeRepository;
    }

    public void CreateOrder(Order order)
    {
        //Console.WriteLine("we are in the service!!!");
        _exchangeRepository.CreateOrder(order);

    }

    // public void CreateOrder(Domain.Entities.Order order)
    // {
    //     throw new NotImplementedException();
    // }
}