using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommandValidator : AbstractValidator<EditOrderCommand>
    {
        public EditOrderCommandValidator()
        {
            RuleFor(p => p.Receiver.FristName)
                .NotNull().NotEmpty().WithMessage(" نام دریافت کننده الزامی میباشد");
            RuleFor(p => p.Receiver.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی دریافت کننده الزامی میباشد");
            RuleFor(p => p.Receiver.Mobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل دریافت کننده الزامی میباشد");
        }
    }
}
