using FluentValidation;

namespace Postex.Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommandValidator : AbstractValidator<UpdateBoxPriceCommand>
    {
        public UpdateBoxPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
