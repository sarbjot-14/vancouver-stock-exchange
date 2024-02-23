using Exchange.Domain.Entities;

namespace Exchange.Application.Util;

public class LevelNode()
{
    public decimal levelPrice;
    public LinkedList<Order>? levelOrders;

}