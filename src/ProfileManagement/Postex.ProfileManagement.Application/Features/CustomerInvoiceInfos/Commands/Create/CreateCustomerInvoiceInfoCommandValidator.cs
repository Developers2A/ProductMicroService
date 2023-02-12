using FluentValidation;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create
{
    public class CreateCustomerInvoiceInfoCommandValidator : AbstractValidator<CreateCustomerInvoiceInfoCommand>
    {
        public CreateCustomerInvoiceInfoCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
