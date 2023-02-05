using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.FirstName)
              .NotEmpty().WithMessage(" نام الزامی میباشد");
        RuleFor(p => p.LastName)
             .NotEmpty().WithMessage(" نام خانوادگی الزامی میباشد");
    }
}
