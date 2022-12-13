using FluentValidation;

namespace Product.Application.Features.CourierServices.Taroff.Queries.GetCities
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
