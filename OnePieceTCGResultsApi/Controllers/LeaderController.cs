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
public class LeaderController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LeaderCreateDto dto)
    {
        await _mediator.Send(new CreateLeaderCommand(dto));
        return Created();
    }
    
    [HttpGet]
    [Route("{id}")]
    [Produces(typeof(LeaderDto))]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _mediator.Send(new GetLeaderQuery(id)));
    }
    
    [HttpGet]
    [Produces(typeof(List<LeaderDto>))]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllLeadersQuery()));
    }
}