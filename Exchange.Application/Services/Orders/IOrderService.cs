namespace Exchange.Application.Services.Orders;
using Exchange.Domain.Entities;
public interface IOrderService
{

     void CreateOrder(Order order);
}