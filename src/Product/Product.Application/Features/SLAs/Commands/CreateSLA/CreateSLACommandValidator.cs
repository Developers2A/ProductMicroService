using FluentValidation;

namespace Product.Application.Features.SLAs.Commands.CreateSLA
{
    public class CreateSLACommandValidator : AbstractValidator<CreateSLACommand>
    {
        public CreateSLACommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");

            RuleFor(p => p.CourierId).
               NotEmpty().NotNull().WithMessage(" کوریر الزامی میباشد");
        }
    }
}
