using FluentValidation;

namespace Product.Application.Features.CourierServices.Taroff.Commands.DeleteOrder
{
    public class DeleteTaroffOrderCommandValidator : AbstractValidator<DeleteTaroffOrderCommand>
    {
        public DeleteTaroffOrderCommandValidator()
        {
            RuleFor(p => p.OrderId)
                  .NotEmpty().NotNull().GreaterThan(0).WithMessage(" شماره سفارش الزامی میباشد");
        }
    }
}
