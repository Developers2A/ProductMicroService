using FluentValidation;

namespace Postex.UserManagement.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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
