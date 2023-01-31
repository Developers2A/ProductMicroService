using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CreateOrder
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
