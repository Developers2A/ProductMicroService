using FluentValidation;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create
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
