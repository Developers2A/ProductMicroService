using FluentValidation;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.CreateValueAddedPrice
{
    public class CreateValueAddedPriceCommandValidator : AbstractValidator<CreateValueAddedPriceCommand>
    {
        public CreateValueAddedPriceCommandValidator()
        {
            RuleFor(p => p.BuyPrice)
                 .NotEmpty().NotNull().WithMessage(" قیمت خرید الزامی میباشد");

            RuleFor(p => p.SellPrice)
                  .NotEmpty().NotNull().WithMessage(" قیمت فروش الزامی میباشد");
        }
    }
}
