using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using Exchange.Application.Services;
using Exchange.Domain.Entities;

namespace Exchange.Application.OrderMatching;


public class OrderBook()
{

    LinkedList<LevelNode> bids = new LinkedList<LevelNode>();
    LinkedList<LevelNode> asks = new LinkedList<LevelNode>();


    public void AddOrder(Order order)
    {
        if (order.side == "buy")
        {

            if (order.side == "market")
            {
                // // check for matching ask orders
                // LevelNode firstLevel = bids.First.Value;
                // if (order.price <= firstLevel.levelPrice)
                // {

                // }
            }
            else
            {
                if (bids.First == null)
                {
                    LevelNode newLevel = new LevelNode();
                    newLevel.levelPrice = order.price;
                    newLevel.levelOrders = new LinkedList<Order>();
                    newLevel.levelOrders.AddLast(order);
                    bids.AddFirst(newLevel);

                }
                else
                {
                    // // market sell order
                    LinkedListNode<LevelNode> current = bids.First;
                    var newOrder = new LinkedListNode<Order>(order);

                    while (current != null)
                    {
                        if (order.price >= current.Value.levelPrice)
                        {
                            if (order.price == current.Value.levelPrice)
                            {

                                LinkedListNode<Order> currentOrder = current.Value.levelOrders.First;

                                if (currentOrder == null)
                                {

                                    current.Value.levelOrders.AddLast(newOrder);
                                    return;

                                }

                                while (current != null)
                                {
                                    if (order.recievedTime > currentOrder.Value.recievedTime)
                                    {
                                        current.Value.levelOrders.AddBefore(currentOrder, newOrder);
                                        return;
                                    }

                                    currentOrder = currentOrder.Next;
                                }
                                current.Value.levelOrders.AddLast(newOrder);

                            }
                            else
                            {
                                LevelNode newLevel = new LevelNode();
                                newLevel.levelPrice = order.price;
                                newLevel.levelOrders = new LinkedList<Order>();
                                newLevel.levelOrders.AddLast(order);
                                LinkedListNode<LevelNode> newLevelNode = new LinkedListNode<LevelNode>(newLevel);
                                bids.AddBefore(current, newLevel);
                            }

                        }


                        current = current.Next;
                    }

                }

            }
        }

    }

    public List<Order> GetBids()
    {
        List<Order> bidsCopy = new List<Order>();

        LinkedListNode<LevelNode> currentLevel = bids.First;
        while (currentLevel != null)
        {
            //bidsCopy.Add(currentLevel)

            LinkedListNode<Order> currentOrder = currentLevel.Value.levelOrders.First;
            while (currentOrder != null)
            {

                bidsCopy.Add(currentOrder.Value);
                currentOrder = currentOrder.Next;
            }


            currentLevel = currentLevel.Next;
        }

        return bidsCopy;

    }


}