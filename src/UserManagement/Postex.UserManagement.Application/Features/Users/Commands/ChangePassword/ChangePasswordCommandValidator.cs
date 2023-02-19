using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(p => p.NewPassword)
            .NotEmpty().NotNull().WithMessage(" کلمه عبور جدید الزامی میباشد");
        RuleFor(p => p.Mobile)
             .NotEmpty().NotNull().WithMessage(" شماره موبایل الزامی میباشد");
        RuleFor(p => p.Mobile)
             .MaximumLength(11).MinimumLength(10).WithMessage(" شماره موبایل حداکثر 11 رقمی می باشد");
    }
}
