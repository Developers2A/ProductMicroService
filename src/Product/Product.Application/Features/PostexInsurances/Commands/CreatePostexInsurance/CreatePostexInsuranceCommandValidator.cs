using FluentValidation;

namespace Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance
{
    public class CreatePostexInsuranceCommandValidator : AbstractValidator<CreatePostexInsuranceCommand>
    {
        public CreatePostexInsuranceCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
