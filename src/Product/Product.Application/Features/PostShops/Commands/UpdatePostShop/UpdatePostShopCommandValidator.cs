using FluentValidation;

namespace Product.Application.Features.PostShops.Commands.UpdatePostShop
{
    public class UpdatePostShopCommandValidator : AbstractValidator<UpdatePostShopCommand>
    {
        public UpdatePostShopCommandValidator()
        {
            RuleFor(p => p.ShopID)
                  .NotEmpty().GreaterThan(0).WithMessage(" شناسه الزامی میباشد");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage(" نام الزامی میباشد");
        }
    }
}
