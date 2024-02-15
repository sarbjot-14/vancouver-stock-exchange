


// using BuberDinner.Application.Services.Authentication;
// using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    // private readonly IAuthenticationService _authenticationService;

    // public AuthenticationController(IAuthenticationService authenticationService)
    // {
    //     _authenticationService = authenticationService;
    // }

    [HttpGet("register")]
    public IActionResult Register()
    {
        // var authResult = _authenticationService.Register(register.FirstName, register.LasrName, register.Email, register.Password);

        // var response = new AuthenticationResponse(authResult.user.Id, authResult.user.FirstName, authResult.user.LastName, authResult.user.Email, authResult.Token);

        return Ok("hi");
    }


}