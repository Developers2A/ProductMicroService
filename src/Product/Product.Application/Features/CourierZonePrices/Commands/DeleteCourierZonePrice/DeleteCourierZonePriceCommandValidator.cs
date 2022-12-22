using FluentValidation;

namespace Product.Application.Features.CourierZonePrices.Commands.DeleteCourierZonePrice
{
    public class DeleteCourierZonePriceCommandValidator : AbstractValidator<DeleteCourierZonePriceCommand>
    {
        public DeleteCourierZonePriceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
