using FluentValidation;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.UpdateCourierServiceZonePrice
{
    public class UpdateCourierServiceZonePriceCommandValidator : AbstractValidator<UpdateCourierServiceZonePriceCommand>
    {
        public UpdateCourierServiceZonePriceCommandValidator()
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
