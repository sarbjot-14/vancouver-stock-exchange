namespace Exchange.Contracts.Order;

public record OrderRequest(
    int account_id,
    string order_class,
    string symbol,
    string side,
    int quantity,
    string type,
    string duration,
    decimal price,
    decimal? stop,
    decimal? trailing


);