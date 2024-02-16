using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnePieceTCGResultsApi.Commands;

namespace OnePieceTCGResultsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class NoteController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("{deckId}")]
    public async Task<IActionResult> Create([FromRoute] int deckId, [FromBody] string text)
    {
        await _mediator.Send(new CreateNoteCommand(deckId, text));
        return Created();
    }
}