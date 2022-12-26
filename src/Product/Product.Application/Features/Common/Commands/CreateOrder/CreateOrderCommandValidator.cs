using FluentValidation;

namespace Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.ReceiverFristName)
                .NotNull().NotEmpty().WithMessage(" نام دریافت کننده الزامی میباشد");
            RuleFor(p => p.ReceiverLastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی دریافت کننده الزامی میباشد");
            RuleFor(p => p.ReceiverMobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل دریافت کننده الزامی میباشد");
        }
    }
}
