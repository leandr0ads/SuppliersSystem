using FluentValidation;

namespace Suppliers.Application.Deliveries.Commands;

public sealed class RegisterDeliveryCommandValidator : AbstractValidator<RegisterDeliveryCommand>
{
    public RegisterDeliveryCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
