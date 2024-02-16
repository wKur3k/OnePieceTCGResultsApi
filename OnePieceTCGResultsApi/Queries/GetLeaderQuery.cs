using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Exceptions;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Queries;

public class GetLeaderQuery : IRequest<LeaderDto>
{
    public int Id { get; set; }

    public GetLeaderQuery(int id)
    {
        Id = id;
    }
}

public class GetLeaderQueryHandler : IRequestHandler<GetLeaderQuery, LeaderDto>
{
    private readonly AppDbContext _dbContext;

    public GetLeaderQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaderDto> Handle(GetLeaderQuery request, CancellationToken cancellationToken)
    {
        var leader = await _dbContext.Leaders.Include(x => x.Colors).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (leader is null)
            throw new NotFoundException("Leader not found.");
        return new LeaderDto() { Name = leader.Name, Colors = leader.Colors.Select(x => x.Name).ToList() };
    }
}