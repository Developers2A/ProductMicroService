using FluentValidation;

namespace Postex.Product.Application.Features.CourierZones.Commands.CreateCourierZone
{
    public class CreateCourierZoneCommandValidator : AbstractValidator<CreateCourierZoneCommand>
    {
        public CreateCourierZoneCommandValidator()
        {
            RuleFor(p => p.CourierId).
                NotEmpty().GreaterThan(0).WithMessage(" شناسه اس ال ای الزامی میباشد");

            RuleFor(p => p.Name).
               NotEmpty().NotNull().WithMessage(" عنوان الزامی میباشد");
        }
    }
}
