using FluentValidation;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommandValidator : AbstractValidator<EditWeightCommand>
    {
        public EditWeightCommandValidator()
        {
            RuleFor(p => p.ParcelCode)
                .NotNull().NotEmpty().WithMessage(" کد پارسل الزامی می باشد");
            RuleFor(p => p.ParcelValue)
               .NotNull().NotEmpty().GreaterThan(0).WithMessage(" ارزش کالا الزامی می باشد");
            RuleFor(p => p.Weight)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("وزن باید بزرگتر از صفر باشد");
        }
    }
}
