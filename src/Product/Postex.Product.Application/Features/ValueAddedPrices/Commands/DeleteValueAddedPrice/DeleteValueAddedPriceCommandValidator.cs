using FluentValidation;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.DeleteValueAddedPrice
{
    public class DeleteValueAddedPriceCommandValidator : AbstractValidator<DeleteValueAddedPriceCommand>
    {
        public DeleteValueAddedPriceCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
