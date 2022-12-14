using FluentValidation;

namespace Product.Application.Features.CourierServices.Commands.CreateCourierService
{
    public class CreateCourierServiceCommandValidator : AbstractValidator<CreateCourierServiceCommand>
    {
        public CreateCourierServiceCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");

            RuleFor(p => p.CourierId).
               NotEmpty().NotNull().WithMessage(" کوریر الزامی میباشد");
        }
    }
}
