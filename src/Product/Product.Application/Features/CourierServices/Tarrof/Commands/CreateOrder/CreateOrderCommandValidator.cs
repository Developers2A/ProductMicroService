using FluentValidation;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.CustomerName)
                  .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
