using FluentValidation;

namespace Postex.Product.Application.Features.Weights.Commands.UpdateWeight
{
    public class UpdateWeightCommandValidator : AbstractValidator<UpdateWeightCommand>
    {
        public UpdateWeightCommandValidator()
        {
            RuleFor(p => p.PostageWeight)
             .NotNull().NotEmpty().WithMessage(" وزن الزامی میباشد");
        }
    }
}
