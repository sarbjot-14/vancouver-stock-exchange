using System.ComponentModel.DataAnnotations;

namespace Exchange.Domain.Entities;

public class Order
{
    [Required]

    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]

    public int account_id { get; set; }
    [Required]

    public string order_class { get; set; }
    [Required]

    public string symbol { get; set; }
    [Required]

    public string side { get; set; }
    [Required]

    public int quantity { get; set; }
    [Required]

    public string type { get; set; }
    [Required]

    public string duration { get; set; }
    [Required]

    public decimal price { get; set; }

    [Required]
    public DateTime recievedTime { get; set; }

    [Required]
    public int quantityFilled { get; set; }


    [Required]
    public decimal? stop { get; set; }
    [Required]

    public decimal? trailing { get; set; }

}