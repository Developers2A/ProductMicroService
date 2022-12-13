using FluentValidation;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.DeleteCourierZoneSLAPrice
{
    public class DeleteCourierZoneSLAPriceCommandValidator : AbstractValidator<DeleteCourierZoneSLAPriceCommand>
    {
        public DeleteCourierZoneSLAPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
