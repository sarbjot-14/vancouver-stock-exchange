namespace Exchange.Contracts.Order;

public record OrderResponse(
    int id,
    string status
);