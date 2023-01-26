using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.CancelOrder
{
    public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(p => p.CourierCode)
                  .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد کوریر الزامی میباشد");
            RuleFor(p => p.TrackCode)
                      .NotNull().NotEmpty().WithMessage(" کد پیگیری الزامی میباشد");
        }
    }
}
