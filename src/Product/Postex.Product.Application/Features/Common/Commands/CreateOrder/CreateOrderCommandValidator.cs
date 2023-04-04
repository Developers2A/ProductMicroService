using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.Courier)
                .NotNull().NotEmpty().WithMessage(" اطلاعات کوریر الزامی میباشد");
            RuleFor(p => p.Courier.ServiceType)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" نوع سرویس الزامی میباشد");
            RuleFor(p => p.Courier.PaymentType)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" نوع پرداخت الزامی میباشد");

            RuleFor(p => p.From)
                .NotNull().NotEmpty().WithMessage(" اطلاعات فرستنده الزامی میباشد");
            RuleFor(p => p.From.Contact)
               .NotNull().NotEmpty().WithMessage(" اطلاعات تماس فرستنده الزامی میباشد");
            RuleFor(p => p.From.Contact.Mobile)
               .NotNull().NotEmpty().WithMessage(" شماره موبایل فرستنده الزامی میباشد");
            RuleFor(p => p.From.Contact.FirstName)
              .NotNull().NotEmpty().WithMessage(" نام فرستنده الزامی میباشد");
            RuleFor(p => p.From.Contact.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی فرستنده الزامی میباشد");

            RuleFor(p => p.From.Location)
             .NotNull().NotEmpty().WithMessage(" اطلاعات آدرس فرستنده الزامی میباشد");
            RuleFor(p => p.From.Location.Address)
                .NotNull().NotEmpty().WithMessage(" آدرس فرستنده الزامی میباشد");
            RuleFor(p => p.From.Location.PostCode)
                .NotNull().NotEmpty().WithMessage(" کدپستی فرستنده الزامی میباشد");
            RuleFor(p => p.From.Location.CityCode)
                .NotNull().NotEmpty().WithMessage(" شهر فرستنده الزامی میباشد");

            RuleFor(p => p.To)
               .NotNull().NotEmpty().WithMessage(" اطلاعات گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact)
                .NotNull().NotEmpty().WithMessage(" اطلاعات تماس گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.FirstName)
                .NotNull().NotEmpty().WithMessage(" نام گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.Mobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل گیرنده الزامی میباشد");

            RuleFor(p => p.To.Location)
                .NotNull().NotEmpty().WithMessage(" اطلاعات آدرس گیرنده الزامی میباشد");
            RuleFor(p => p.To.Location.Address)
                .NotNull().NotEmpty().WithMessage(" آدرس گیرنده الزامی میباشد");
            RuleFor(p => p.To.Location.PostCode)
                .NotNull().NotEmpty().WithMessage(" کدپستی گیرنده الزامی میباشد");
            RuleFor(p => p.To.Location.CityCode)
                .NotNull().NotEmpty().WithMessage(" شهر گیرنده الزامی میباشد");

            RuleFor(p => p.Parcel)
                .NotNull().NotEmpty().WithMessage(" اطلاعات بسته الزامی میباشد");
            RuleFor(p => p.Parcel.Width)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" عرض بسته الزامی میباشد");
            RuleFor(p => p.Parcel.Height)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" ارتفاع بسته الزامی میباشد");
            RuleFor(p => p.Parcel.Length)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" طول بسته الزامی میباشد");
            RuleFor(p => p.Parcel.TotalWeight)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" وزن بسته الزامی میباشد");
            RuleFor(p => p.Parcel.TotalValue)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" ارزش بسته الزامی میباشد");
        }
    }
}
