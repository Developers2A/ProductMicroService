using FluentValidation;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices
{
    public class CreateCourierZonePricesCommandValidator : AbstractValidator<CreateCourierZonePricesCommand>
    {
        public CreateCourierZonePricesCommandValidator()
        {
            //RuleFor(p => p.CourierZoneId).
            //    NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
        }
    }
}
