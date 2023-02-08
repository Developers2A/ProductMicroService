using FluentValidation;

namespace Pouya.Application.Features.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.UserName)
              .NotEmpty().WithMessage(" نام کاربری الزامی میباشد");
        RuleFor(p => p.Password)
              .NotEmpty().WithMessage(" کلمه عبور الزامی میباشد");
    }
}
