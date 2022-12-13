using FluentValidation;

namespace Product.Application.Features.CourierServices.Bsw.Commands.CreateOrder
{
    public class CreateBswOrderCommandValidator : AbstractValidator<CreateBswOrderCommand>
    {
        public CreateBswOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //      .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
