using Exchange.Domain.Entities;

namespace Exchange.Application.Interfaces.Persistence;

public interface IExchangeRepository{

    void CreateOrder(Order order);
}