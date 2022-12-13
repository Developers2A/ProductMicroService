using FluentValidation;

namespace Product.Application.Features.CourierLimitValues.Commands.DeleteCourierLimitValue
{

    public class DeleteCourierLimitValueCommandValidator : AbstractValidator<DeleteCourierLimitValueCommand>
    {
        public DeleteCourierLimitValueCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage(" شناسه الزامی میباشد");
        }
    }
}
