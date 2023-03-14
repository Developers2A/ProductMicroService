using FluentValidation;

namespace Postex.Product.Application.Features.Cities.Queries.GetCitiesCommon
{
    public class GetCitiesCommonQueryValidator : AbstractValidator<GetCitiesCommonQuery>
    {
        public GetCitiesCommonQueryValidator()
        {
            RuleFor(p => p.ProvinceCode)
                  .NotEmpty().NotNull().WithMessage(" کد استان الزامی میباشد");
        }
    }
}
