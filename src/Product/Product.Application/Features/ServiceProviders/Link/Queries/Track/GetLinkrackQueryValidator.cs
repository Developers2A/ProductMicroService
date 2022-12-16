using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Link.Queries.Track
{
    public class GetLinkrackQueryValidator : AbstractValidator<GetLinkTrackQuery>
    {
        public GetLinkrackQueryValidator()
        {
            RuleFor(p => p.TrackingCode)
              .NotNull().NotEmpty().WithMessage(" کد سفارش الزامی می باشد");
        }
    }
}
