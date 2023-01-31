using FluentValidation;

namespace Postex.Product.Application.Features.CourierZones.Commands.DeleteCourierZone
{
    public class DeleteCourierZoneCommandValidator : AbstractValidator<DeleteCourierZoneCommand>
    {
        public DeleteCourierZoneCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");
        }
    }
}
