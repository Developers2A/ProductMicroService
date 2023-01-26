using FluentValidation;

namespace Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit
{
    public class UpdateCourierLimitCommandValidator : AbstractValidator<UpdateCourierLimitCommand>
    {
        public UpdateCourierLimitCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage(" نام الزامی میباشد");
        }
    }
}
