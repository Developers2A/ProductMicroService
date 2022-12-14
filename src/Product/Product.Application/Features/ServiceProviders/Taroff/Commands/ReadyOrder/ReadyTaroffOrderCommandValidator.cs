using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Taroff.Commands.ReadyOrder
{
    public class ReadyTaroffOrderCommandValidator : AbstractValidator<ReadyTaroffOrderCommand>
    {
        public ReadyTaroffOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شناسه سفارش الزامی میباشد");
        }
    }
}
