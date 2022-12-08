using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Commands.CreateShop
{
    public class CreatePostShopCommandValidator : AbstractValidator<CreatePostShopCommand>
    {
        public CreatePostShopCommandValidator()
        {
            RuleFor(p => p.CityID)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه شهر الزامی می باشد");
            RuleFor(p => p.PostUnitID)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" ناحیه پستی الزامی می باشد");
            RuleFor(p => p.PostnodeID)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد نقطه مبادله الزامی می باشد");
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage(" نام الزامی می باشد");
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage(" شماره تماس الزامی می باشد");
            RuleFor(p => p.CollectTypeID)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" نوع جمع آوری الزامی می باشد");
            RuleFor(p => p.Mob)
                .NotNull().NotEmpty().Length(11).WithMessage(" موبایل را به صورت 09 وارد کنید");
            RuleFor(p => p.ManagerBirthDate)
                .NotNull().NotEmpty().Length(10).WithMessage(" تاریخ تولد مدیر فروشگاه را بصورت 1401/01/01 وارد کنید");
        }
    }
}
