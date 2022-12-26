using FluentValidation;

namespace Product.Application.Features.Common.Queries.Track
{
    public class GetTrackQueryValidator : AbstractValidator<GetTrackQuery>
    {
        public GetTrackQueryValidator()
        {
            RuleFor(p => p.CourierCode)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" کوریر الزامی می باشد");
            RuleFor(p => p.TrackCode)
                .NotNull().NotEmpty().WithMessage(" کد بسته الزامی می باشد");
        }
    }
}
