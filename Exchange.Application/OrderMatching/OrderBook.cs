using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using Exchange.Application.Services;
using Exchange.Domain.Entities;
using Exchange.Domain.Enums;

namespace Exchange.Application.OrderMatching;


public class OrderBook()
{

    LinkedList<LevelNode> bids = new LinkedList<LevelNode>();
    LinkedList<LevelNode> asks = new LinkedList<LevelNode>();


    public void AddOrder(Order order)
    {
        LinkedList<LevelNode> orderBookSide = order.side == Side.Buy ? bids : asks;
    

        if (order.type == OrderTypes.Market)
        {
            // // check for matching ask orders

        }
        else
        {
            if (orderBookSide.First == null)
            {
                //empty orderBookSide
                LevelNode newLevel = new LevelNode();
                newLevel.levelPrice = order.price;
                newLevel.levelOrders = new LinkedList<Order>();
                newLevel.levelOrders.AddLast(order);
                orderBookSide.AddFirst(newLevel);

            }
            else
            {
                // find level
                LinkedListNode<LevelNode> current = orderBookSide.First;
                var newOrder = new LinkedListNode<Order>(order);
                Func<decimal, decimal, bool> priceComparison = order.side == Side.Buy ? (x, y) => x <= y : (x, y) => x >= y;


                while (current != null)
                {
                    if (priceComparison(order.price, current.Value.levelPrice))
                    {
                        if (order.price == current.Value.levelPrice)
                        {
                            //add to level
                            LinkedListNode<Order> currentOrder = current.Value.levelOrders.First;

                            if (currentOrder == null)
                            {

                                current.Value.levelOrders.AddLast(newOrder);
                                return;

                            }
                            else
                            {
                                while (currentOrder != null)
                                {
                                    if (order.recievedTime > currentOrder.Value.recievedTime)
                                    {
                                        current.Value.levelOrders.AddBefore(currentOrder, newOrder);
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
                        // add level before current 
                        LevelNode newLevel = new LevelNode();
                        newLevel.levelPrice = order.price;
                        newLevel.levelOrders = new LinkedList<Order>();
                        newLevel.levelOrders.AddLast(order);

                        LinkedListNode<LevelNode> newLevelNode = new LinkedListNode<LevelNode>(newLevel);
                        orderBookSide.AddBefore(current, newLevel);
                        return;
                    }
                    //add another level to end
                    if (current.Next == null)
                    {
                        LevelNode newLevel = new LevelNode();
                        newLevel.levelPrice = order.price;
                        newLevel.levelOrders = new LinkedList<Order>();
                        newLevel.levelOrders.AddLast(order);

                        LinkedListNode<LevelNode> newLevelNode = new LinkedListNode<LevelNode>(newLevel);
                        orderBookSide.AddAfter(current, newLevel);
                        return;
                    }

                    current = current.Next;

                }
            }

        }
    }



    public List<Order> GetOrders(Side side)
    {
        List<Order> ordersCopy = new List<Order>();

        LinkedListNode<LevelNode> currentLevel = side == Side.Buy ? bids.First : asks.First;
        while (currentLevel != null)
        {
            LinkedListNode<Order> currentOrder = currentLevel.Value.levelOrders.First;
            while (currentOrder != null)
            {
                ordersCopy.Add(currentOrder.Value);
                currentOrder = currentOrder.Next;
            }


            currentLevel = currentLevel.Next;
        }
        return ordersCopy;

    }


}