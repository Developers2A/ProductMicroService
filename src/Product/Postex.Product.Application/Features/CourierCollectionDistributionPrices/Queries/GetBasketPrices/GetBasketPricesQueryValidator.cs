using FluentValidation;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQueryValidator : AbstractValidator<GetBasketPricesQuery>
    {
        public GetBasketPricesQueryValidator()
        {
            RuleFor(model => model.Basket)
                .Must(x => x == null || x.Parcels.Count > 0)
                .WithMessage("درخواست شما خالی است، لطفا بسته ها را اضافه کنید");

            RuleFor(p => p.Basket.CourierCode)
                .NotNull().NotEmpty().WithMessage(" کوریر الزامی میباشد");

            RuleFor(p => p.Basket.CityTypeCode)
                .NotNull().NotEmpty().WithMessage(" نوع شهر الزامی میباشد");

            RuleFor(p => p.Basket.ServiceType)
               .NotEmpty().NotNull().WithMessage(" کد سرویس الزامی میباشد");

            RuleFor(p => p.Basket.BasketId)
               .NotEmpty().NotNull().WithMessage(" کد سبد الزامی میباشد");
        }
    }
}