using FluentValidation;

namespace Product.Application.Features.CourierServices.Post.Queries.GetCities
{
    public class GetPostCitiesQueryValidator : AbstractValidator<GetPostCitiesQuery>
    {
        public GetPostCitiesQueryValidator()
        {
            RuleFor(p => p.ProvinceId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه استان الزامی میباشد");
        }
    }
}
