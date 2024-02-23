using Exchange.Domain.Entities;

namespace Exchange.Application.OrderMatching;

public class LevelNode()
{
    public decimal levelPrice;
    public LinkedList<Order>? levelOrders;

}