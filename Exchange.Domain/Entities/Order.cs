namespace Exchange.Domain.Entities;

public class Order{
    public Guid Id { get; set;} = Guid.NewGuid();

    public int account_id {get; set;}
    public string order_class {get; set;}
    public string symbol {get; set;}
    public string side {get; set;}
    public int quantity {get; set;}
    public string type {get; set;}
    public string duration {get; set;}
    public decimal price {get; set;}
    public decimal? stop {get; set;}
    public decimal? trailing {get; set;}

}