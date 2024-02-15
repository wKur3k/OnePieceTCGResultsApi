using FluentValidation;
using OnePieceTCGResultsApi.Entities;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Models.Validators;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Username)
            .MinimumLength(7);
        RuleFor(x => x.Password)
            .MinimumLength(8);
        RuleFor(x => x.ConfirmPassword)
            .Equal(e => e.Password)
            .WithMessage("Passwords are not identical.");
        RuleFor(x => x.Username)
            .Custom((value, context) =>
            {
                if (dbContext.Users.Any(u => u.Username == value))
                    context.AddFailure("Username", "This username is taken.");
            });
    }
}