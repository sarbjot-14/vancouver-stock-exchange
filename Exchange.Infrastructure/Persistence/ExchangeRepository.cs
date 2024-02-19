using System.Security.Cryptography;
using Exchange.Application.Interfaces.Persistence;
using Exchange.Domain.Entities;

namespace Exchange.Infrastracture.Persistence;

public class ExchangeRepository : IExchangeRepository
{
    private readonly List<Order> orders = new List<Order>();

    public void CreateOrder(Order order)
    {
        //TODO: replace with in memory database with entity framework
        orders.Add(order);
    }
}