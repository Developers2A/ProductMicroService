using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.GetCities
{
    public class GetTaroffCitiesQueryValidator : AbstractValidator<GetTaroffCitiesQuery>
    {
        public GetTaroffCitiesQueryValidator()
        {
            RuleFor(p => p.ProvinceId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه استان الزامی میباشد");
        }
    }
}
