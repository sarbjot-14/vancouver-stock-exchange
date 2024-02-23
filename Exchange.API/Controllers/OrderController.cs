using System.Security.Cryptography;
using Exchange.Application.Services.Orders;
using Exchange.Contracts;
using Exchange.Contracts.EntityExtensions;
using Exchange.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderEngineService _orderService;
    public OrderController(IOrderEngineService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public IActionResult CreateOrder(OrderRequestDto orderRequestDto)
    {
        Order newOrder = orderRequestDto.ToOrder();
        this._orderService.CreateOrder(newOrder);

        return Ok("whoooo hoo");
    }

}