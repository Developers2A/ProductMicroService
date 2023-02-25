using FluentValidation;

namespace Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Update
{
    public class UpdateCustomerInvoiceInfoCommandValidator : AbstractValidator<UpdateCustomerInvoiceInfoCommand>
    {
        public UpdateCustomerInvoiceInfoCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
