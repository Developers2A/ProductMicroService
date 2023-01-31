using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CreateOrder
{
    public class CreateTaroffOrderCommandValidator : AbstractValidator<CreateTaroffOrderCommand>
    {
        public CreateTaroffOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
