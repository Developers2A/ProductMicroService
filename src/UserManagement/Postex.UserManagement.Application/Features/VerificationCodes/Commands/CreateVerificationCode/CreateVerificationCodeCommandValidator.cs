using FluentValidation;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommandValidator : AbstractValidator<CreateVerificationCodeCommand>
{
    public CreateVerificationCodeCommandValidator()
    {
        RuleFor(p => p.Mobile)
             .NotEmpty().NotNull().WithMessage(" شماره موبایل الزامی میباشد");
        RuleFor(p => p.Mobile)
             .MaximumLength(11).MinimumLength(10).WithMessage(" شماره موبایل حداکثر 11 رقمی می باشد");
    }
}
