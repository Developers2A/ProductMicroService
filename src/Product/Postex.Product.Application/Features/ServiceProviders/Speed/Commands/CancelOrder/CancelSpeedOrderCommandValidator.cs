using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder
{
    public class CancelSpeedOrderCommandValidator : AbstractValidator<CancelSpeedOrderCommand>
    {
        public CancelSpeedOrderCommandValidator()
        {
            RuleFor(p => p.Barcode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" بارکد الزامی میباشد");
        }
    }
}
