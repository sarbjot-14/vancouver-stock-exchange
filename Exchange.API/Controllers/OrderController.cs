using System.Security.Cryptography;
using Exchange.Application.Services.Order;
using Exchange.Contracts.Order;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder(OrderRequest orderRequest)
    {
        this._orderService.CreateOrder();

        return Ok("whoooo hoo");
    }

}