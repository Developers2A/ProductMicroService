using FluentValidation;

namespace Product.Application.Features.CourierServices.Tarrof.Commands.CancelOrder
{
    public class SuspendOrderCommandValidator : AbstractValidator<SuspendOrderCommand>
    {
        public SuspendOrderCommandValidator()
        {
        }
    }
}
