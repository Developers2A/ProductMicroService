using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Post.Commands.ReadyToCollectOrder
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
