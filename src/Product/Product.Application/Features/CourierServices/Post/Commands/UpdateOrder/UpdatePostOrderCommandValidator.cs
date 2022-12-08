using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Commands.UpdateOrder
{
    public class UpdatePostOrderCommandValidator : AbstractValidator<UpdatePostOrderCommand>
    {
        public UpdatePostOrderCommandValidator()
        {
            RuleFor(p => p.CustomerName)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
