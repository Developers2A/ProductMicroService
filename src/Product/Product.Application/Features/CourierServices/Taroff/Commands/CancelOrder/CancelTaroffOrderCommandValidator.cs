using FluentValidation;

namespace Product.Application.Features.CourierServices.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommandValidator : AbstractValidator<CancelTaroffOrderCommand>
    {
        public CancelTaroffOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شماره سفارش الزامی میباشد");
        }
    }
}
