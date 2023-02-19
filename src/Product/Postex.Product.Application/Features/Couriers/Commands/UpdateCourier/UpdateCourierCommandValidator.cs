using FluentValidation;

namespace Postex.Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommandValidator : AbstractValidator<UpdateCourierCommand>
    {
        public UpdateCourierCommandValidator()
        {
            RuleFor(p => p.Id)
                  .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
