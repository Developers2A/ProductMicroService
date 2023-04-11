using FluentValidation;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPudoPrice
{
    public class GetPudoPriceQueryValidator : AbstractValidator<GetPudoPriceQuery>
    {
        public GetPudoPriceQueryValidator()
        {
            RuleFor(p => p.CityCode)
                  .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کد شهر الزامی میباشد");
        }
    }
}
