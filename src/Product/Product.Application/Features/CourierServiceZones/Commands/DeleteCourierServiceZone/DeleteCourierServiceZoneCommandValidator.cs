using FluentValidation;

namespace Product.Application.Features.CourierServiceZones.Commands.DeleteCourierServiceZone
{
    public class DeleteCourierServiceZoneCommandValidator : AbstractValidator<DeleteCourierServiceZoneCommand>
    {
        public DeleteCourierServiceZoneCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");
        }
    }
}
