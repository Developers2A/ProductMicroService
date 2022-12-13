using FluentValidation;

namespace Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue
{
    public class EditCourierLimitValueCommandValidator : AbstractValidator<UpdateCourierLimitValueCommand>
    {
        public EditCourierLimitValueCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().NotNull().WithMessage("شناسه الزامی می باشد");

            RuleFor(p => p.LowerLimit)
              .NotEmpty().NotNull().WithMessage("محدوده پایین الزامی می باشد");

            RuleFor(p => p.UpperLimit)
             .NotEmpty().NotNull().WithMessage("محدوده بالا الزامی می باشد");
        }
    }
}
