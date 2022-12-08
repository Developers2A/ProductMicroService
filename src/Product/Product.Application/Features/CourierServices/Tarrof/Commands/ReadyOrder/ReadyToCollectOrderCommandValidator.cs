using FluentValidation;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.ReadyOrder
{
    public class ReadyToCollectOrderCommandValidator : AbstractValidator<ReadyToCollectOrderCommand>
    {
        public ReadyToCollectOrderCommandValidator()
        {
            RuleFor(p => p.ParcelCodes)
               .NotEmpty().NotNull().WithMessage(" کدهای پارسل الزامی میباشد");
        }
    }
}
