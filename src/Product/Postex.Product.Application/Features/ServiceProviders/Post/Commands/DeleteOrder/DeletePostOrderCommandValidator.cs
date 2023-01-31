using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.DeleteOrder
{
    public class DeletePostOrderCommandValidator : AbstractValidator<DeletePostOrderCommand>
    {
        public DeletePostOrderCommandValidator()
        {
            RuleFor(p => p.ParcelCodes)
                  .NotEmpty().NotNull().WithMessage(" کدهای پارسل الزامی میباشد");
        }
    }
}
