using FluentValidation;

namespace Product.Application.Features.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommandValidator : AbstractValidator<CreatePeykOrderCommand>
    {
        public CreatePeykOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
