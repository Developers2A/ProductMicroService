using FluentValidation;

namespace Product.Application.Features.CourierCods.Commands.CreateCourierCod
{
    public class CreateCourierCodCommandValidator : AbstractValidator<CreateCourierCodCommand>
    {
        public CreateCourierCodCommandValidator()
        {
            RuleFor(p => p.CourierId)
               .NotEmpty().GreaterThan(0).WithMessage("کوریر الزامی میباشد");
        }
    }
}
