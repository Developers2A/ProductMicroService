using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.AuthenticateUser;

public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidator()
    {
        RuleFor(p => p.Password)
            .NotEmpty().NotNull().WithMessage(" کلمه عبور الزامی میباشد");

        RuleFor(p => p.UserName)
              .NotEmpty().NotNull().WithMessage(" نام کاربری الزامی میباشد");
    }
}
