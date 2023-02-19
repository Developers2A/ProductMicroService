using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Mobile)
             .NotEmpty().NotNull().WithMessage(" شماره موبایل الزامی میباشد");
        RuleFor(p => p.Mobile)
             .MaximumLength(11).MinimumLength(10).WithMessage(" شماره موبایل حداکثر 11 رقمی می باشد");
        RuleFor(p => p.Password)
             .NotEmpty().WithMessage(" رمز عبور الزامی میباشد");
        RuleFor(p => p.RePassword)
            .NotEmpty().WithMessage(" تکرا رمز عبور الزامی میباشد");
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage(" نام الزامی میباشد");
        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage(" نام خانوادگی الزامی میباشد");
    }
}
