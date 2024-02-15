using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnePieceTCGResultsApi.Commands;
using OnePieceTCGResultsApi.Models.Dtos;
using OnePieceTCGResultsApi.Queries;

namespace OnePieceTCGResultsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    [Produces(typeof(int))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto dto)
    {
        return Ok(await _mediator.Send(new CreateUserCommand(dto)));
    }

    [HttpPost]
    [Route("login")]
    [Produces(typeof(string))]
    public async Task<IActionResult> LoginUser([FromBody] UserLoginDto dto)
    {
        return Ok(await _mediator.Send(new CreateJwtTokenQuery(dto)));
    }
    
}