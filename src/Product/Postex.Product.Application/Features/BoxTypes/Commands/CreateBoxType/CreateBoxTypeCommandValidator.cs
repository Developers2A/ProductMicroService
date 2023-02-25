using FluentValidation;

namespace Postex.Product.Application.Features.BoxTypes.Commands.CreateBoxType
{
    public class CreateBoxTypeCommandValidator : AbstractValidator<CreateBoxTypeCommand>
    {
        public CreateBoxTypeCommandValidator()
        {
            RuleFor(p => p.Name)
             .NotEmpty().NotNull().WithMessage(" نام الزامی میباشد");

            RuleFor(p => p.Height)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" ارتفاع الزامی میباشد");

            RuleFor(p => p.Width)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" عرض الزامی میباشد");

            RuleFor(p => p.Length)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" طول الزامی میباشد");

        }
    }
}
