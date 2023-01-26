using FluentValidation;

namespace Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit
{
    public class CreateCourierLimitCommandValidator : AbstractValidator<CreateCourierLimitCommand>
    {
        public CreateCourierLimitCommandValidator()
        {
            RuleFor(p => p.Name).
                NotEmpty().NotNull().WithMessage(" نام الزامی میباشد");
        }
    }
}
