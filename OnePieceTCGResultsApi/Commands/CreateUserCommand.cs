using MediatR;
using Microsoft.EntityFrameworkCore;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Exceptions;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Commands;

public class CreateUserCommand : IRequest<int>
{
    public UserRegisterDto Dto { get; set; }

    public CreateUserCommand(UserRegisterDto dto)
    {
        Dto = dto;
    }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly AppDbContext _dbContext;

    public CreateUserCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == RoleId.USER, cancellationToken);

        if (userRole is null)
            throw new ServiceUnavailableException("Couldn't register new user. Contact admin to resolve this issue.");
        
        var newUser = new User()
        {
            Username = request.Dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Dto.Password),
            Roles = new List<Role>()
        };
        
        newUser.Roles.Add(userRole);
        
        await _dbContext.Users.AddAsync(newUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return newUser.Id;
    }
}