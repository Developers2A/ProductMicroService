using FluentValidation;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Update;

namespace Postex.ProfileManagement.Application.Features.Customers.Commands.Create
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
