using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.GetPrice
{
    public class GetPriceQueryValidator : AbstractValidator<GetPriceQuery>
    {
        public GetPriceQueryValidator()
        {
            RuleFor(p => p.Sender.ProvinceCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" استان فرستنده الزامی میباشد");
            RuleFor(p => p.Sender.CityCode)
                .NotNull().NotEmpty().WithMessage(" شهر فرستنده الزامی می باشد");
            RuleFor(p => p.Receiver.ProvinceCode)
               .NotNull().NotEmpty().WithMessage(" استان گیرنده الزامی می باشد");
            RuleFor(p => p.Receiver.CityCode)
               .NotNull().NotEmpty().WithMessage(" شهر گیرنده الزامی می باشد");
            RuleFor(p => p.Parcel.BoxTypeId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" نوع جعبه الزامی می باشد");
        }
    }
}
