using FluentValidation;

namespace Postex.Product.Application.Features.PostShops.Commands.SyncPostShops
{
    public class SyncPostShopsCommandValidator : AbstractValidator<SyncPostShopsCommand>
    {
        public SyncPostShopsCommandValidator()
        {
            RuleFor(p => p.FromDate)
                  .NotEmpty().NotNull().WithMessage(" تاریخ شروع الزامی میباشد");

            RuleFor(p => p.ToDate)
                .NotEmpty().NotNull().WithMessage(" تاریخ پایان الزامی میباشد");
        }
    }
}
