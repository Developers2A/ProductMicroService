using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Mahex.Commands.CreateOrder
{
    public class CreateMahexOrderCommandValidator : AbstractValidator<CreateMahexOrderCommand>
    {
        public CreateMahexOrderCommandValidator()
        {
            //RuleFor(p => p.CustomerName)
            //.NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
