using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.GetPrice
{
    public class GetPriceQueryValidator : AbstractValidator<GetPriceQuery>
    {
        public GetPriceQueryValidator()
        {
            RuleFor(p => p.SenderProvinceCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" استان فرستنده الزامی میباشد");
            RuleFor(p => p.SenderCityCode)
                .NotNull().NotEmpty().WithMessage(" شهر فرستنده الزامی می باشد");
            RuleFor(p => p.ReceiverProvinceCode)
               .NotNull().NotEmpty().WithMessage(" استان گیرنده الزامی می باشد");
            RuleFor(p => p.ReceiverCityCode)
               .NotNull().NotEmpty().WithMessage(" شهر گیرنده الزامی می باشد");
            RuleFor(p => p.BoxTypeId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" نوع جعبه الزامی می باشد");
        }
    }
}
