using Exchange.Contracts;
using Exchange.Domain.Entities;
namespace Exchange.Contracts.EntityExtensions;


public static class OrderExtensions
{

    public static OrderResponseDto ToResponseDto(this Order order)
    {

        return new OrderResponseDto(order.Id, "submitted", order.account_id, order.order_class, order.symbol, order.side, order.quantity, order.type, order.duration, order.price, order?.stop, order?.trailing);

    }

    public static Order ToOrder(this OrderRequestDto orderRequestDto)
    {

        return new Order { account_id = orderRequestDto.account_id, order_class = orderRequestDto.order_class, symbol = orderRequestDto.symbol, side = orderRequestDto.side, quantity = orderRequestDto.quantity, type = orderRequestDto.type, duration = orderRequestDto.duration, price = orderRequestDto.price, stop = orderRequestDto?.stop, trailing = orderRequestDto?.trailing, recievedTime = new DateTime(), quantityFilled = 0 };

    }
}