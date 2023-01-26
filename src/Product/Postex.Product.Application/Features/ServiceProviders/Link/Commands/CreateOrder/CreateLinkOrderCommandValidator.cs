using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Link.Commands.CreateOrder
{
    public class CreateLinkOrderCommandValidator : AbstractValidator<CreateLinkOrderCommand>
    {
        public CreateLinkOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
