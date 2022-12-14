using FluentValidation;

namespace Product.Application.Features.CourierServices.Commands.UpdateCourierService
{
    public class UpdateCourierServiceCommandValidator : AbstractValidator<UpdateCourierServiceCommand>
    {
        public UpdateCourierServiceCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
