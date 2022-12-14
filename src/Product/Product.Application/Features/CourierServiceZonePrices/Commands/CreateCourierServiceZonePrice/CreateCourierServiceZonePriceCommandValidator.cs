using FluentValidation;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.CreateCourierServiceZonePrice
{
    public class CreateCourierServiceZonePriceCommandValidator : AbstractValidator<CreateCourierServiceZonePricePriceCommand>
    {
        public CreateCourierServiceZonePriceCommandValidator()
        {
            RuleFor(p => p.CourierServiceZoneId).
                NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
            RuleFor(p => p.VolumeId).
               NotEmpty().GreaterThan(0).WithMessage(" حجم الزامی میباشد");
            RuleFor(p => p.WeightId).
               NotEmpty().GreaterThan(0).WithMessage(" وزن الزامی میباشد");
            RuleFor(p => p.SellPrice).
                NotEmpty().GreaterThan(0).WithMessage(" قیمت فروش باید بزرگتر از صفر باشد");
            RuleFor(p => p.BuyPrice).
                NotEmpty().GreaterThan(0).WithMessage(" قیمت خرید باید بزرگتر از صفر باشد");
        }
    }
}
