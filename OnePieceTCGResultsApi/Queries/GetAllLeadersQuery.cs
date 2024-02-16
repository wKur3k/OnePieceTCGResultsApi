using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Queries;

public class GetAllLeadersQuery : IRequest<List<LeaderDto>>{}

public class GetAllLeadersQueryHandler : IRequestHandler<GetAllLeadersQuery, List<LeaderDto>>
{
    private readonly AppDbContext _dbContext;

    public GetAllLeadersQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<LeaderDto>> Handle(GetAllLeadersQuery request, CancellationToken cancellationToken)
    {
        var leaders = await _dbContext.Leaders.Include(x => x.Colors).ToListAsync();
        var leadersDto = new List<LeaderDto>();
        leaders.ForEach(x => leadersDto.Add(new LeaderDto(){Name = x.Name, Colors = x.Colors.Select(c => c.Name).ToList()}));
        return leadersDto;
    }
}