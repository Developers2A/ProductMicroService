using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CancelOrder
{
    public class CancelEcoPeykOrderCommandValidator : AbstractValidator<CancelEcoPeykOrderCommand>
    {
        public CancelEcoPeykOrderCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotNull().NotEmpty().WithMessage(" کد الزامی میباشد");
        }
    }
}
