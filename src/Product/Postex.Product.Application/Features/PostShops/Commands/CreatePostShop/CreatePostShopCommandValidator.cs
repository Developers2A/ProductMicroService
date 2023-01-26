using FluentValidation;

namespace Postex.Product.Application.Features.PostShops.Commands.CreatePostShop
{
    public class CreatePostShopCommandValidator : AbstractValidator<CreatePostShopCommand>
    {
        public CreatePostShopCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
