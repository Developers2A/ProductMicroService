using FluentValidation;

namespace Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommandValidator : AbstractValidator<CreateBoxPriceCommand>
    {
        public CreateBoxPriceCommandValidator()
        {
            RuleFor(p => p.SellPrice)
                  .NotEmpty().NotNull().WithMessage(" قیمت فروش الزامی میباشد");

            RuleFor(p => p.BuyPrice)
                 .NotEmpty().NotNull().WithMessage(" قیمت خرید الزامی میباشد");
        }
    }
}
