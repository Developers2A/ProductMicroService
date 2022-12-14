using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(p => p.ParcelCodes)
                  .NotEmpty().NotNull().WithMessage(" کدهای پارسل الزامی میباشد");
        }
    }
}
