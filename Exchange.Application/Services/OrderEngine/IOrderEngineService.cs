namespace Exchange.Application.Services.Orders;
using Exchange.Domain.Entities;
public interface IOrderEngineService
{

     void CreateOrder(Order order);

     List<Order> GetOrders(Side side, string ticker);
}