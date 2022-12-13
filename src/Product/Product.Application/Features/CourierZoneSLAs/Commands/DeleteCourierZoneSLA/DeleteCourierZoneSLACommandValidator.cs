using FluentValidation;

namespace Product.Application.Features.CourierZoneSLAs.Commands.DeleteCourierZoneSLA
{
    public class DeleteCourierZoneSLACommandValidator : AbstractValidator<DeleteCourierZoneSLACommand>
    {
        public DeleteCourierZoneSLACommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");
        }
    }
}
