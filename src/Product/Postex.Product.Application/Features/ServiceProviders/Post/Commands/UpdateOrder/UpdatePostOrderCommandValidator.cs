using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Commands.UpdateOrder
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
