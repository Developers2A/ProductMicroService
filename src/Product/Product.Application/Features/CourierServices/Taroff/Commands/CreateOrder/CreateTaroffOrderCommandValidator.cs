using FluentValidation;

namespace Product.Application.Features.CourierServices.Taroff.Commands.CreateOrder
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
