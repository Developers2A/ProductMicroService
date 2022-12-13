using FluentValidation;

namespace Product.Application.Features.CourierLimits.Commands.DeleteCourierLimit
{
    public class DeleteCourierLimitCommandValidator : AbstractValidator<DeleteCourierLimitCommand>
    {
        public DeleteCourierLimitCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
