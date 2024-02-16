using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnePieceTCGResultsApi.Queries;

namespace OnePieceTCGResultsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class DeckController : ControllerBase
{
    private readonly IMediator _mediator;

    public DeckController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    [Produces(typeof(List<string>))]
    public async Task<IActionResult> GetNotes([FromRoute] int id)
    {
        return Ok(await _mediator.Send(new GetNotesForDeckQuery(id)));
    }
}