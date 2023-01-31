using FluentValidation;

namespace Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService
{
    public class CreateCourierServiceCommandValidator : AbstractValidator<CreateCourierServiceCommand>
    {
        public CreateCourierServiceCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().NotNull().WithMessage(" عنوان سرویس الزامی میباشد");
        }
    }
}
