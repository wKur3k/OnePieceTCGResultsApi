using FluentValidation;
using OnePieceTCGResultsApi.Models.Dtos;

namespace OnePieceTCGResultsApi.Models.Validators;

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .MinimumLength(7);
        RuleFor(x => x.Password)
            .MinimumLength(8);
    }
}