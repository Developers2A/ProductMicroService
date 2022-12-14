using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder
{
    public class CancelSpeedOrderCommandValidator : AbstractValidator<CancelSpeedOrderCommand>
    {
        public CancelSpeedOrderCommandValidator()
        {
            //  RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
