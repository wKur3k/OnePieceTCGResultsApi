using MediatR;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Exceptions;

namespace OnePieceTCGResultsApi.Commands;

public class CreateNoteCommand : IRequest
{
    public int DeckId { get; set; }
    public string Text { get; set; }

    public CreateNoteCommand(int deckId, string text)
    {
        DeckId = deckId;
        Text = text;
    }
}

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand>
{
    private readonly AppDbContext _dbContext;

    public CreateNoteCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        if (!_dbContext.Decks.Any(x => x.Id == request.DeckId))
            throw new NotFoundException("Deck not found.");
        await _dbContext.Notes.AddAsync(new Note() { DeckId = request.DeckId, Text = request.Text }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}