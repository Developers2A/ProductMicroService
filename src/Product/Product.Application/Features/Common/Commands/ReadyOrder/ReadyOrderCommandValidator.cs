using FluentValidation;

namespace Product.Application.Features.Common.Commands.ReadyOrder
{
    public class ReadyOrderCommandValidator : AbstractValidator<ReadyOrderCommand>
    {
        public ReadyOrderCommandValidator()
        {
            RuleFor(p => p.CourierCode)
              .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد کوریر الزامی میباشد");
            RuleFor(p => p.TrackCode)
                      .NotNull().NotEmpty().WithMessage(" کد پیگیری الزامی میباشد");
        }
    }
}
