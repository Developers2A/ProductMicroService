using FluentValidation;

namespace Pouya.Application.Features.Users.Commands;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage(" شناسه الزامی میباشد");
    }
}
