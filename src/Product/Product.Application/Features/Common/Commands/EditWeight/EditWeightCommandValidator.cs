using FluentValidation;

namespace Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommandValidator : AbstractValidator<EditWeightCommand>
    {
        public EditWeightCommandValidator()
        {
            RuleFor(p => p.ParcelId)
                .NotNull().NotEmpty().WithMessage(" کد پارسل الزامی میباشد");
            RuleFor(p => p.SenderMobile)
                .NotNull().NotEmpty().WithMessage(" موبایل فرستنده الزامی میباشد");
            RuleFor(p => p.Weight)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("وزن باید بزرگتر از صفر باشد");
        }
    }
}
