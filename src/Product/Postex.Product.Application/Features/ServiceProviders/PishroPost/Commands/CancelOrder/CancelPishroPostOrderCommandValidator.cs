using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Commands.CancelOrder
{
    public class CancelPishroPostOrderCommandValidator : AbstractValidator<CancelPishroPostOrderCommand>
    {
        public CancelPishroPostOrderCommandValidator()
        {
            RuleFor(p => p.ConsignmentNo)
                .NotNull().NotEmpty().WithMessage(" بارکد الزامی میباشد");
        }
    }
}
