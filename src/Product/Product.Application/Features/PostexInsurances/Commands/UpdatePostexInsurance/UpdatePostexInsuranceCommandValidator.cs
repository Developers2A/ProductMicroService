using FluentValidation;

namespace Product.Application.Features.PostexInsurances.Commands.UpdatePostexInsurance
{
    public class UpdatePostexInsuranceCommandValidator : AbstractValidator<UpdatePostexInsuranceCommand>
    {
        public UpdatePostexInsuranceCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }

}
