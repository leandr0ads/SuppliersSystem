using FluentValidation;

namespace Suppliers.Application.Suppliers.Commands;

public sealed class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Cnpj).NotEmpty().Length(14).WithMessage("CNPJ must have 14 digits.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
