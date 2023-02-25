using FluentValidation;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
{
    public class UpdateValueAddedPriceCommandValidator : AbstractValidator<UpdateValueAddedPriceCommand>
    {
        public UpdateValueAddedPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().NotNull().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.BuyPrice)
                  .NotEmpty().NotNull().WithMessage(" قیمت خرید الزامی میباشد");

            RuleFor(p => p.SellPrice)
                  .NotEmpty().NotNull().WithMessage(" قیمت فروش الزامی میباشد");
        }
    }
}
