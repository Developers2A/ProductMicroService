using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.GetQuickPrice
{
    public class GetQuickPriceQueryValidator : AbstractValidator<GetQuickPriceQuery>
    {
        public GetQuickPriceQueryValidator()
        {
            RuleFor(p => p.SenderStateCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" استان فرستنده الزامی میباشد");
            RuleFor(p => p.SenderCityCode)
                .NotNull().NotEmpty().WithMessage(" شهر فرستنده الزامی می باشد");
            RuleFor(p => p.ReceiverStateCode)
               .NotNull().NotEmpty().WithMessage(" استان گیرنده الزامی می باشد");
            RuleFor(p => p.ReceiverCityCode)
               .NotNull().NotEmpty().WithMessage(" شهر گیرنده الزامی می باشد");
        }
    }
}
