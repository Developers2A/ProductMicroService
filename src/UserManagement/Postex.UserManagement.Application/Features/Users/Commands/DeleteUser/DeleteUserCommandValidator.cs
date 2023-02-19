using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage(" شناسه الزامی میباشد");
    }
}
