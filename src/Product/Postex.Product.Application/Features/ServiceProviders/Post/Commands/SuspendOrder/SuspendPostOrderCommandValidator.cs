using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.SuspendOrder
{
    public class SuspendPostOrderCommandValidator : AbstractValidator<SuspendPostOrderCommand>
    {
        public SuspendPostOrderCommandValidator()
        {
        }
    }
}
