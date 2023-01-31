using FluentValidation;

namespace Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance
{
    public class UpdateCourierInsuranceCommandValidator : AbstractValidator<UpdateCourierInsuranceCommand>
    {
        public UpdateCourierInsuranceCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }

}
