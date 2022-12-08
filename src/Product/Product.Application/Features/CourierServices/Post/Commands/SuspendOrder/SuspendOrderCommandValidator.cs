using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Commands.SuspendOrder
{
    public class SuspendOrderCommandValidator : AbstractValidator<SuspendOrderCommand>
    {
        public SuspendOrderCommandValidator()
        {
        }
    }
}
