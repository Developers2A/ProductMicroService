using FluentValidation;

namespace Postex.Product.Application.Features.BoxPrices.Commands.DeleteBoxPrice
{
    public class DeleteBoxPriceCommandValidator : AbstractValidator<DeleteBoxPriceCommand>
    {
        public DeleteBoxPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
