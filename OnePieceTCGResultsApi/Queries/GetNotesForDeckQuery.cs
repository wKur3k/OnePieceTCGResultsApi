using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Queries;

public class GetNotesForDeckQuery : IRequest<List<string>>
{
    public int DeckId { get; set; }

    public GetNotesForDeckQuery(int deckId)
    {
        DeckId = deckId;
    }
}

public class GetNotesForDeckQueryHandler : IRequestHandler<GetNotesForDeckQuery, List<string>>
{
    private readonly AppDbContext _dbContext;

    public GetNotesForDeckQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<string>> Handle(GetNotesForDeckQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Notes.Where(x => x.DeckId == request.DeckId).Select(x => x.Text).ToListAsync(cancellationToken);
    }
}