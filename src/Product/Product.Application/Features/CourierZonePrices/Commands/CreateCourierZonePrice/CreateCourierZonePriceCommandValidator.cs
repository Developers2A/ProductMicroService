using FluentValidation;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice
{
    public class CreateCourierZonePriceCommandValidator : AbstractValidator<CreateCourierZonePriceCommand>
    {
        public CreateCourierZonePriceCommandValidator()
        {
            RuleFor(p => p.CourierServiceId).
                NotEmpty().NotNull().GreaterThan(0).WithMessage(" شناسه سرویس الزامی میباشد");
            RuleFor(p => p.FromCourierZoneId).
                NotEmpty().NotNull().GreaterThan(0).WithMessage(" زون مبدا الزامی میباشد");
            RuleFor(p => p.ToCourierZoneId).
                NotEmpty().NotNull().GreaterThan(0).WithMessage(" زون مقصد الزامی میباشد");
            RuleFor(p => p.Weight).
               NotEmpty().NotNull().GreaterThan(0).WithMessage(" وزن الزامی میباشد");
            RuleFor(p => p.BuyPrice).
                NotEmpty().NotNull().GreaterThan(0).WithMessage(" قیمت خرید باید بزرگتر از صفر باشد");
        }
    }
}
