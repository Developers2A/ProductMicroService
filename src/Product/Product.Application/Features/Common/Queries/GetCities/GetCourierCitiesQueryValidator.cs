using FluentValidation;

namespace Product.Application.Features.Common.Queries.GetCities
{
    public class GetCourierCitiesQueryValidator : AbstractValidator<GetCourierCitiesQuery>
    {
        public GetCourierCitiesQueryValidator()
        {
            RuleFor(p => p.CourierCode)
                  .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی میباشد");
            RuleFor(p => p.StateId)
                  .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه استان الزامی میباشد");
        }
    }
}
