using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Bsw.Commands.CancelOrder
{
    public class CancelBswOrderCommandValidator : AbstractValidator<CancelBswOrderCommand>
    {
        public CancelBswOrderCommandValidator()
        {
            RuleFor(p => p.OrderNumber)
                .NotNull().NotEmpty().WithMessage("  شماره سفارش الزامی میباشد");
        }
    }
}
