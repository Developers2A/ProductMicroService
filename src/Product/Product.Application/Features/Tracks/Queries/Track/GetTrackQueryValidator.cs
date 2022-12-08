using FluentValidation;

namespace Product.Application.Features.Tracks.Queries.Track
{
    public class GetTrackQueryValidator : AbstractValidator<GetTrackQuery>
    {
        public GetTrackQueryValidator()
        {
            RuleFor(p => p.Courier)
                .NotNull().NotEmpty().Length(3).WithMessage(" کوریر دارای سه حرف انگلیسی می باشد");
            RuleFor(p => p.TrackingCode)
                .NotNull().NotEmpty().WithMessage(" کد بسته الزامی می باشد");
        }
    }
}
