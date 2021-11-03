using FluentValidation;

namespace MLA.ClientOrder.Application.Features.Order.Command.AddOrder
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                .NotNull()
                .WithMessage("Order Can not be null or empty");

            RuleFor(p => p.ClientId)
                .NotNull()
                .WithMessage("Client Can not be null or empty");

            RuleFor(p => p.LeadLayerId)
                .NotNull()
                .WithMessage("Lead lawyer Can not be null or empty");
        }
    }
}
