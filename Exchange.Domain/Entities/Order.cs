using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using Exchange.Domain.Enums;

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
    public Side side { get; set; }

    [Required]
    public int quantity { get; set; }

    [Required]
    public OrderTypes type { get; set; }

    [Required]
    public string duration { get; set; }

    [Required]
    public decimal price { get; set; }
    //Todo: make price null

    [Required]
    public DateTime recievedTime { get; set; }

    [Required]
    public int quantityFilled { get; set; }

    [Required]
    public decimal bookValue { get; set; }

    [Required]
    public decimal? averageCost
    {
        get
        {
            if (quantityFilled != 0)
            {
                return bookValue / quantityFilled;
            }
            else
            {
                return null;
            }

        }

    }


    [Required]
    public decimal? stop { get; set; }

    [Required]
    public decimal? trailing { get; set; }


}

