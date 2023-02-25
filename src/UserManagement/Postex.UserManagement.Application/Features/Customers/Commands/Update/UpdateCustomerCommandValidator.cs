using FluentValidation;

namespace Postex.UserManagement.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
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
