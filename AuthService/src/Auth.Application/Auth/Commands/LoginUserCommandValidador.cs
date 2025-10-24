using FluentValidation;

namespace Auth.Application.Auth.Commands;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
