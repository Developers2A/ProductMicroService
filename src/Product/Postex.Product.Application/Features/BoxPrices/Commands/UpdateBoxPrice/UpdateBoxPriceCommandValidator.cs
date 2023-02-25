using FluentValidation;

namespace Postex.Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommandValidator : AbstractValidator<UpdateBoxPriceCommand>
    {
        public UpdateBoxPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().NotNull().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.SellPrice)
                  .NotEmpty().NotNull().WithMessage(" قیمت فروش الزامی میباشد");

            RuleFor(p => p.BuyPrice)
                 .NotEmpty().NotNull().WithMessage(" قیمت خرید الزامی میباشد");
        }
    }
}
