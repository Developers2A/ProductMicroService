using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.LoginUserWithOtp;

public class LoginUserWithOtpCommandValidator : AbstractValidator<LoginUserWithOtpCommand>
{
    public LoginUserWithOtpCommandValidator()
    {
        RuleFor(p => p.Mobile)
            .NotEmpty().NotNull().MaximumLength(11).WithMessage(" شماره موبایل را به درستی وارد نمایید");
    }
}
