
using System.ComponentModel.DataAnnotations;

namespace Exchange.Contracts;
public record OrderRequestDto(
    [Required]
    int account_id,
    [Required]
    string order_class,
    [Required]
    string symbol,
    [Required]
    string side,
    [Required]
    int quantity,
    [Required]
    string type,
    [Required]
    string duration,
    decimal price,
    decimal? stop,
    decimal? trailing


);


public record OrderResponseDto(
    [Required]
    Guid id,
    [Required]
    string status,
    [Required]
    int account_id,
    [Required]
    string order_class,
    [Required]
    string symbol,
    [Required]
    string side,
    [Required]
    int quantity,
    [Required]
    string type,
    [Required]
    string duration,
    [Required]
    decimal fillPrice,
    decimal? stop,
    decimal? trailing
);