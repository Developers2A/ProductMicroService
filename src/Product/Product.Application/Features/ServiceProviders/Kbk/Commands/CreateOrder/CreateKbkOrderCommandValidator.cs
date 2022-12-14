using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder
{
    public class CreateKbkOrderCommandValidator : AbstractValidator<CreateKbkOrderCommand>
    {
        public CreateKbkOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
