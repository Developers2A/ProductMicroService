using FluentValidation;

namespace Pouya.Application.Features.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage(" شناسه الزامی میباشد");

        RuleFor(p => p.UserName)
              .NotEmpty().WithMessage(" نام کاربری الزامی میباشد");
    }
}
