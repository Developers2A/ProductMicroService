using FluentValidation;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.DeleteCourierServiceZonePrice
{
    public class DeleteCourierServiceZonePriceCommandValidator : AbstractValidator<DeleteCourierServiceZonePriceCommand>
    {
        public DeleteCourierServiceZonePriceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
