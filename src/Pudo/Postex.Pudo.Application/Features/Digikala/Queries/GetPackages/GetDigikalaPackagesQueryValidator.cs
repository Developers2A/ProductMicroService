using FluentValidation;

namespace Postex.Pudo.Application.Features.Digikala.Queries.GetPackages;

public class GetDigikalaPackagesQueryValidator : AbstractValidator<GetDigikalaPackagesQuery>
{
    public GetDigikalaPackagesQueryValidator()
    {
        RuleFor(p => p.StartDate)
            .NotNull().NotEmpty().WithMessage(" تاریخ شروع الزامی میباشد");
        RuleFor(p => p.EndDate)
            .NotNull().NotEmpty().WithMessage(" تاریخ پایان الزامی میباشد");
    }
}
