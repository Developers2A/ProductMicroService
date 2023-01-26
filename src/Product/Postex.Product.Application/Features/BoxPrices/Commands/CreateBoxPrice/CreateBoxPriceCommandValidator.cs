using FluentValidation;

namespace Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommandValidator : AbstractValidator<CreateBoxPriceCommand>
    {
        public CreateBoxPriceCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
