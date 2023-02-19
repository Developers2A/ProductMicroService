using FluentValidation;

namespace Postex.Application.Features.VerificationCodes.Commands.UpdateVerificationCode;

public class UpdateVerificationCodeCommandValidator : AbstractValidator<UpdateVerificationCodeCommand>
{
    public UpdateVerificationCodeCommandValidator()
    {
        RuleFor(p => p.Mobile)
             .NotEmpty().NotNull().WithMessage(" شماره موبایل الزامی میباشد");
        RuleFor(p => p.Mobile)
             .MaximumLength(11).MinimumLength(10).WithMessage(" شماره موبایل حداکثر 11 رقمی می باشد");
        RuleFor(p => p.Code)
             .NotEmpty().NotNull().GreaterThan(0).WithMessage(" کد اعتبارسنجی الزامی میباشد");
    }
}
