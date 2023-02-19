using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(p => p.Password)
            .NotEmpty().NotNull().WithMessage(" کلمه عبور الزامی می باشد و باید حداقل 5 کارکتر باشد");

        RuleFor(p => p.Mobile)
              .NotEmpty().NotNull().MaximumLength(11).WithMessage(" شماره موبایل را به درستی وارد نمایید");
    }
}
