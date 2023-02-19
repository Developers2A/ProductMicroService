using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.VerifiyCode;

public class VerifyCodeCommandValidator : AbstractValidator<VerifyCodeCommand>
{
    public VerifyCodeCommandValidator()
    {
        RuleFor(p => p.Mobile)
             .NotEmpty().NotNull().WithMessage(" شماره موبایل الزامی میباشد");
        RuleFor(p => p.Mobile)
             .MaximumLength(11).MinimumLength(10).WithMessage(" شماره موبایل حداکثر 11 رقمی می باشد");
        RuleFor(p => p.Code)
             .NotEmpty().NotNull().GreaterThan(1000).WithMessage(" کد تایید الزامی میباشد");
    }
}
