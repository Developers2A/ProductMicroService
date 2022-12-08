using FluentValidation;

namespace Product.Application.Features.CourierServices.Tarrof.Queries.GetProvinces
{
    public class GetPostUnitsQueryValidator : AbstractValidator<GetPostUnitsQuery>
    {
        public GetPostUnitsQueryValidator()
        {
            RuleFor(p => p.ProvinceId)
                .NotNull().NotEmpty().WithMessage(" شناسه شهر الزامی میباشد");
        }
    }
}
