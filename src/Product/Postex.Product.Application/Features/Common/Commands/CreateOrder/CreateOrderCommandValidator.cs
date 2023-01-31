using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.CourierServiceCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد سرویس الزامی میباشد");
            RuleFor(p => p.ReceiverFristName)
                .NotNull().NotEmpty().WithMessage(" نام گیرنده الزامی میباشد");
            RuleFor(p => p.ReceiverLastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی گیرنده الزامی میباشد");
            RuleFor(p => p.ReceiverMobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل گیرنده الزامی میباشد");
        }
    }
}
