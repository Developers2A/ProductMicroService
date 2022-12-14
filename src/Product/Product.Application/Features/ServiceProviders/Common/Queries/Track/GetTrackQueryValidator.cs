using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Common.Queries.Track
{
    public class GetTrackQueryValidator : AbstractValidator<GetTrackQuery>
    {
        public GetTrackQueryValidator()
        {
            RuleFor(p => p.Courier)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کوریر دارای سه حرف انگلیسی می باشد");
            RuleFor(p => p.TrackingCode)
                .NotNull().NotEmpty().WithMessage(" کد بسته الزامی می باشد");
        }
    }
}
