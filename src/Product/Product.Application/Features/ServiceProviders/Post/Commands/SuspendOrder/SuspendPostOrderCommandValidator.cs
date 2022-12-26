using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder
{
    public class SuspendPostOrderCommandValidator : AbstractValidator<SuspendPostOrderCommand>
    {
        public SuspendPostOrderCommandValidator()
        {
        }
    }
}
