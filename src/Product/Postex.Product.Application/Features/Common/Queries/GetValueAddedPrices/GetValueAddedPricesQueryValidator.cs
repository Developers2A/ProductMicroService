using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.GetValueAddedPrices;

public class GetValueAddedPricesQueryValidator : AbstractValidator<GetValueAddedPricesQuery>
{
    public GetValueAddedPricesQueryValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotNull().NotEmpty().WithMessage(" شناسه مشتری الزامی میباشد");
        RuleFor(p => p.CityId)
            .NotNull().NotEmpty().WithMessage(" شناسه شهر الزامی میباشد");
        RuleFor(p => p.StateId)
            .NotNull().NotEmpty().WithMessage(" شناسه استان الزامی میباشد");
        RuleFor(p => p.ValueAddedIds)
            .NotNull().NotEmpty().WithMessage(" سرویس های ارزش افزوده الزامی میباشد");
    }
}
