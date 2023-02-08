using FluentValidation;

namespace Pouya.Application.Features.Users.Commands;

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
