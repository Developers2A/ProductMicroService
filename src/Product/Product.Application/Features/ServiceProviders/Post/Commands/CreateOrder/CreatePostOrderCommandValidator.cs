using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Post.Commands.CreateOrder
{
    public class CreatePostOrderCommandValidator : AbstractValidator<CreatePostOrderCommand>
    {
        public CreatePostOrderCommandValidator()
        {
            RuleFor(p => p.CustomerName)
                  .NotNull().NotEmpty().WithMessage(" نام مشتری الزامی میباشد");
        }
    }
}
