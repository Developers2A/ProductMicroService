using FluentValidation;

namespace Product.Application.Features.CourierServices.PishroPost.Commands.CreateOrder
{
    public class CreatePishroPostOrderCommandValidator : AbstractValidator<CreatePishroPostOrderCommand>
    {
        public CreatePishroPostOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
