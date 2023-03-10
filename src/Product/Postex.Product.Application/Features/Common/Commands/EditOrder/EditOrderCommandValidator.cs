using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommandValidator : AbstractValidator<EditOrderCommand>
    {
        public EditOrderCommandValidator()
        {
            RuleFor(p => p.To.Contact)
                .NotNull().NotEmpty().WithMessage(" اطلاعات دریافت کننده الزامی میباشد");
            RuleFor(p => p.To.Contact.FirstName)
                .NotNull().NotEmpty().WithMessage(" نام دریافت کننده الزامی میباشد");
            RuleFor(p => p.To.Contact.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی دریافت کننده الزامی میباشد");
            RuleFor(p => p.To.Contact.Mobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل دریافت کننده الزامی میباشد");
        }
    }
}
