using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName).
                NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            RuleFor(p => p.FirstName).
                NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
            RuleFor(p => p.Email)
               .EmailAddress().WithMessage("فرمت آدرس ایمیل معتبر نمی باشد");
        }
    }
}
