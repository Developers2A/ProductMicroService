using FluentValidation;

namespace Product.Application.Features.CourierZonePrices.Commands.UpdateCourierZonePrice
{
    public class UpdateCourierZonePriceCommandValidator : AbstractValidator<UpdateCourierZonePriceCommand>
    {
        public UpdateCourierZonePriceCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId).
               NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.StateId).
                NotEmpty().GreaterThan(0).WithMessage(" استان الزامی میباشد");
        }
    }
}
