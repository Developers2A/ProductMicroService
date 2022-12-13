using FluentValidation;

namespace Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue
{
    public class CreateCourierLimitValueCommandValidator : AbstractValidator<CreateCourierLimitValueCommand>
    {
        public CreateCourierLimitValueCommandValidator()
        {
            RuleFor(p => p.CourierId)
               .NotEmpty().GreaterThan(0).WithMessage("کوریر الزامی میباشد");

            RuleFor(p => p.LowerLimit)
               .NotEmpty().NotNull().WithMessage("محدوده پایین الزامی می باشد");

            RuleFor(p => p.UpperLimit)
             .NotEmpty().NotNull().WithMessage("محدوده بالا الزامی می باشد");
        }
    }
}
