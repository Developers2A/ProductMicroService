using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(p => p.Token)
             .NotEmpty().NotNull().WithMessage(" توکن الزامی میباشد");
        RuleFor(p => p.RefreshToken)
             .NotEmpty().WithMessage(" رفرش توکن الزامی میباشد");
    }
}
