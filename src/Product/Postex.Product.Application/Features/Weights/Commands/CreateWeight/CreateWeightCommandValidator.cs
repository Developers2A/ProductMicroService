using FluentValidation;

namespace Postex.Product.Application.Features.Weights.Commands.CreateWeight
{
    public class CreateWeightCommandValidator : AbstractValidator<CreateWeightCommand>
    {
        public CreateWeightCommandValidator()
        {
            RuleFor(p => p.PostageWeight)
                  .NotNull().NotEmpty().WithMessage(" وزن الزامی میباشد");
        }
    }
}
