using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Chapar.Commands.CreateOrder
{
    public class CreateChaparOrderCommandValidator : AbstractValidator<CreateChaparOrderCommand>
    {
        public CreateChaparOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
