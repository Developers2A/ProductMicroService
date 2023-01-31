using FluentValidation;

namespace Postex.Product.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandValidator : AbstractValidator<CreateCourierCommand>
    {
        public CreateCourierCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage(" نام الزامی میباشد");

            RuleFor(p => p.Code)
                .NotEmpty().NotNull().WithMessage(" کد الزامی میباشد");
        }
    }
}
