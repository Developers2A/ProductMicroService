using FluentValidation;

namespace Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance
{
    public class CreateCourierInsuranceCommandValidator : AbstractValidator<CreateCourierInsuranceCommand>
    {
        public CreateCourierInsuranceCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
