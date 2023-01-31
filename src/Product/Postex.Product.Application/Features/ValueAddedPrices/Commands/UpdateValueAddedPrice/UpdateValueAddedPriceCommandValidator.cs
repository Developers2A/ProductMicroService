using FluentValidation;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
{
    public class UpdateValueAddedPriceCommandValidator : AbstractValidator<UpdateValueAddedPriceCommand>
    {
        public UpdateValueAddedPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
