using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder
{
    public class SuspendOrderCommandValidator : AbstractValidator<SuspendOrderCommand>
    {
        public SuspendOrderCommandValidator()
        {
        }
    }
}
