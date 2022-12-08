using FluentValidation;

namespace Product.Application.Features.CourierServices.Tarrof.Queries.GetCities
{
    public class GetPostNodesQueryValidator : AbstractValidator<GetPostNodesQuery>
    {
        public GetPostNodesQueryValidator()
        {
            RuleFor(p => p.CityId)
                .NotNull().NotEmpty().WithMessage(" شناسه شهر الزامی میباشد");
        }
    }
}
