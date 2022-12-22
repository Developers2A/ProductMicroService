using FluentValidation;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice
{
    public class CreateCourierZonePriceCommandValidator : AbstractValidator<CreateCourierZonePriceCommand>
    {
        public CreateCourierZonePriceCommandValidator()
        {
            RuleFor(p => p.FromCourierZoneId).
                NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
            RuleFor(p => p.ToCourierZoneId).
                NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
            RuleFor(p => p.Weight).
               NotEmpty().GreaterThan(0).WithMessage(" وزن الزامی میباشد");
            RuleFor(p => p.BuyPrice).
                NotEmpty().GreaterThan(0).WithMessage(" قیمت خرید باید بزرگتر از صفر باشد");
        }
    }
}
