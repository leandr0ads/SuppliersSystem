using FluentValidation;

namespace Auth.Application.Auth.Commands;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress().WithMessage("Valid email is required.");

        RuleFor(x => x.Password)
            .NotEmpty().MinimumLength(6).WithMessage("Password must have at least 6 characters.");
    }
}
