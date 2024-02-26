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
                    //empty bids
                    LevelNode newLevel = new LevelNode();
                    newLevel.levelPrice = order.price;
                    newLevel.levelOrders = new LinkedList<Order>();
                    newLevel.levelOrders.AddLast(order);
                    Console.WriteLine($"adding first one {order.Id}");
                    bids.AddFirst(newLevel);

                }
                else
                {
                    // find level
                    LinkedListNode<LevelNode> current = bids.First;
                    var newOrder = new LinkedListNode<Order>(order);

                    while (current != null)
                    {
                        if (order.price <= current.Value.levelPrice)
                        {
                            if (order.price == current.Value.levelPrice)
                            {
                                //add to level
                                LinkedListNode<Order> currentOrder = current.Value.levelOrders.First;

                                if (currentOrder == null)
                                {

                                    current.Value.levelOrders.AddLast(newOrder);
                                    Console.WriteLine($"adding if level order is empty {order.Id}");
                                    return;

                                }
                                else
                                {
                                    while (currentOrder != null)
                                    {
                                        if (order.recievedTime > currentOrder.Value.recievedTime)
                                        {
                                            current.Value.levelOrders.AddBefore(currentOrder, newOrder);
                                            Console.WriteLine($"adding in while loop {order.Id}");
                                            return;
                                        }

                                        currentOrder = currentOrder.Next;
                                    }
                                    current.Value.levelOrders.AddLast(newOrder);
                                    return;
                                }

                            }


                        }
                        else
                        {
                            // add level before current level
                            LevelNode newLevel = new LevelNode();
                            newLevel.levelPrice = order.price;
                            newLevel.levelOrders = new LinkedList<Order>();
                            newLevel.levelOrders.AddLast(order);
                            Console.WriteLine($"adding last {order.Id}");

                            LinkedListNode<LevelNode> newLevelNode = new LinkedListNode<LevelNode>(newLevel);
                            bids.AddBefore(current, newLevel); //TODO: add after?
                            return;
                        }
                        //add another level to end
                        if (current.Next == null)
                        {
                            LevelNode newLevel = new LevelNode();
                            newLevel.levelPrice = order.price;
                            newLevel.levelOrders = new LinkedList<Order>();
                            newLevel.levelOrders.AddLast(order);
                            Console.WriteLine($"adding last at end {order.Id}");

                            LinkedListNode<LevelNode> newLevelNode = new LinkedListNode<LevelNode>(newLevel);
                            bids.AddAfter(current, newLevel);
                            return;
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