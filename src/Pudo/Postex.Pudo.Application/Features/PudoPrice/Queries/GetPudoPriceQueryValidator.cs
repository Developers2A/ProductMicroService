using FluentValidation;

namespace Postex.Pudo.Application.Features.PudoPrice.Queries;

public class GetPudoPriceQueryValidator : AbstractValidator<GetPudoPriceQuery>
{
    public GetPudoPriceQueryValidator()
    {
        RuleFor(p => p.CityName)
            .NotNull().NotEmpty().WithMessage(" شهر الزامی میباشد");
    }
}
