using FluentValidation;

namespace Product.Application.Features.CourierServices.Link.Queries.Track
{
    public class GetLinkrackQueryValidator : AbstractValidator<GetLinkTrackQuery>
    {
        public GetLinkrackQueryValidator()
        {
            RuleFor(p => p.ShipmentCode)
              .NotNull().NotEmpty().WithMessage(" کد سفارش الزامی می باشد");
        }
    }
}
