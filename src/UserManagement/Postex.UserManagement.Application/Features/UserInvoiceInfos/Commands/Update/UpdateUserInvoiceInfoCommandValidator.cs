using FluentValidation;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Update
{
    public class UpdateUserInvoiceInfoCommandValidator : AbstractValidator<UpdateUserInvoiceInfoCommand>
    {
        public UpdateUserInvoiceInfoCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
