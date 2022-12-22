using FluentValidation;

namespace Product.Application.Features.CourierServices.Commands.UpdateCourierService
{
    public class UpdateCourierServiceCommandValidator : AbstractValidator<UpdateCourierServiceCommand>
    {
        public UpdateCourierServiceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().NotNull().WithMessage(" عنوان سرویس الزامی میباشد");
        }
    }
}
