using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.EditParcel
{
    public class EditParcelCommandValidator : AbstractValidator<EditParcelCommand>
    {
        public EditParcelCommandValidator()
        {
            RuleFor(p => p.To.Contact)
                .NotNull().NotEmpty().WithMessage(" اطلاعات گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.NationalCode)
             .NotNull().NotEmpty().WithMessage(" کد ملی گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.FirstName)
                .NotNull().NotEmpty().WithMessage(" نام گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.LastName)
                .NotNull().NotEmpty().WithMessage(" نام خانوادگی گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.Mobile)
                .NotNull().NotEmpty().WithMessage(" شماره موبایل گیرنده الزامی میباشد");
            RuleFor(p => p.To.Location.PostCode)
                .NotNull().NotEmpty().WithMessage(" کد پستی گیرنده الزامی میباشد");
            RuleFor(p => p.To.Contact.Email)
                .EmailAddress().WithMessage(" ایمیل گیرنده را به درستی وارد نمایید");
        }
    }
}
