using FluentValidation;

namespace Postex.Pudo.Application.Features.DigikalaPudoPrice.Queries.DigikalaPudoPrices;

public class GetDigikalaPudoPricesQueryValidator : AbstractValidator<GetDigikalaPudoPricesQuery>
{
    public GetDigikalaPudoPricesQueryValidator()
    {
        RuleFor(p => p.StartDate)
            .NotNull().NotEmpty().WithMessage(" تاریخ شروع الزامی میباشد");
        RuleFor(p => p.EndDate)
            .NotNull().NotEmpty().WithMessage(" تاریخ پایان الزامی میباشد");
    }
}
