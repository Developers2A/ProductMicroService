using FluentValidation;

namespace Postex.Product.Application.Features.Common.Queries.Track
{
    public class GetTrackQueryValidator : AbstractValidator<GetTrackQuery>
    {
        public GetTrackQueryValidator()
        {
            RuleFor(p => p.CourierCode)
                .NotNull().NotEmpty().GreaterThan(0).LessThan(12).WithMessage(" کد کوریر عددی بین یک تا یازده می باشد");
            RuleFor(p => p.TrackCode)
                .NotNull().NotEmpty().WithMessage(" کد بسته الزامی می باشد");
        }
    }
}
