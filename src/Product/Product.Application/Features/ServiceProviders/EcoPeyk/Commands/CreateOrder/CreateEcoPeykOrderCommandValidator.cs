using FluentValidation;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CreateOrder
{
    public class CreateEcoPeykOrderCommandValidator : AbstractValidator<CreateEcoPeykOrderCommand>
    {
        public CreateEcoPeykOrderCommandValidator()
        {
            RuleFor(p => p.Type)
                  .NotNull().NotEmpty().WithMessage(" نوع درخواست الزامی میباشد");
        }
    }
}
