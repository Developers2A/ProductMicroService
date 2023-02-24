using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.CourierServiceCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد سرویس الزامی میباشد");
            RuleFor(p => p.Sender)
                .NotNull().NotEmpty().WithMessage(" اطلاعات فرستنده الزامی میباشد");
            RuleFor(p => p.Sender.Mobile)
               .NotNull().NotEmpty().WithMessage(" شماره موبایل فرستنده الزامی میباشد");
            RuleFor(p => p.Receiver)
               .NotNull().NotEmpty().WithMessage(" اطلاعات گیرنده الزامی میباشد");
            RuleFor(p => p.Receiver.FristName)
                .NotNull().NotEmpty().WithMessage(" نام گیرنده الزامی میباشد");
            RuleFor(p => p.Receiver.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی گیرنده الزامی میباشد");
            RuleFor(p => p.Receiver.Mobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل گیرنده الزامی میباشد");
            RuleFor(p => p.Width)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" عرض بسته الزامی میباشد");
            RuleFor(p => p.Height)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" ارتفاع بسته الزامی میباشد");
            RuleFor(p => p.Length)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" طول بسته الزامی میباشد");
            RuleFor(p => p.Weight)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" وزن بسته الزامی میباشد");
        }
    }
}
