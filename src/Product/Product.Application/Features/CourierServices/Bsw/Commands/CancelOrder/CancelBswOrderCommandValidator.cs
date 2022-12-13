using FluentValidation;

namespace Product.Application.Features.CourierServices.Bsw.Commands.CancelOrder
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
