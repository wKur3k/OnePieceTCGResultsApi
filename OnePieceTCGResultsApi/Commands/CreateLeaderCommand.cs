using MediatR;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Commands;

public class CreateLeaderCommand : IRequest
{
    public LeaderCreateDto Dto { get; set; }

    public CreateLeaderCommand(LeaderCreateDto dto)
    {
        Dto = dto;
    }
}

public class CreateLeaderCommandHandler : IRequestHandler<CreateLeaderCommand>
{
    private readonly AppDbContext _dbContext;

    public CreateLeaderCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateLeaderCommand request, CancellationToken cancellationToken)
    {
        var newLeader = new Leader()
        {
            Name = request.Dto.Name,
            Colors = _dbContext.Colors.Where(c => request.Dto.Colors.Contains(c.ColorId)).ToList(),
            Deck = new Deck()
        };
        await _dbContext.Leaders.AddAsync(newLeader, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}