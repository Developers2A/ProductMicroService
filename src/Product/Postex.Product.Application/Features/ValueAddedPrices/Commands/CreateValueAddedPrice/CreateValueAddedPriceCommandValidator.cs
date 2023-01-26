using FluentValidation;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.CreateValueAddedPrice
{
    public class CreateValueAddedPriceCommandValidator : AbstractValidator<CreateValueAddedPriceCommand>
    {
        public CreateValueAddedPriceCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
