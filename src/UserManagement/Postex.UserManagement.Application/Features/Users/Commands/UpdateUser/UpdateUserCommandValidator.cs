using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.UpdateUser;

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
