using FluentValidation;

namespace Product.Application.Features.CourierZones.Commands.UpdateCourierZone
{
    public class UpdateCourierZoneCommandValidator : AbstractValidator<UpdateCourierZoneCommand>
    {
        public UpdateCourierZoneCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.CourierId).
               NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.Name).
                NotEmpty().NotNull().WithMessage(" عنوان الزامی میباشد");
        }
    }
}
