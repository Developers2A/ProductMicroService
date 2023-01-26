using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.GetPrice
{
    public class GetPriceQueryValidator : AbstractValidator<GetPriceQuery>
    {
        public GetPriceQueryValidator()
        {
            RuleFor(p => p.SenderState)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" استان فرستنده الزامی میباشد");
            RuleFor(p => p.SenderCity)
                .NotNull().NotEmpty().WithMessage(" شهر فرستنده الزامی می باشد");
            RuleFor(p => p.ReceiverState)
               .NotNull().NotEmpty().WithMessage(" استان گیرنده الزامی می باشد");
            RuleFor(p => p.ReceiverCity)
               .NotNull().NotEmpty().WithMessage(" شهر گیرنده الزامی می باشد");
        }
    }
}
