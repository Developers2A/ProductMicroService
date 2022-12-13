using FluentValidation;

namespace Product.Application.Features.CourierServices.Bsw.Queries.Track
{
    public class TrackBswOrderCommandValidator : AbstractValidator<TrackBswCommand>
    {
        public TrackBswOrderCommandValidator()
        {
            RuleFor(p => p.OrderNumber)
                  .NotNull().NotEmpty().WithMessage("  شماره سفارش الزامی میباشد");
        }
    }
}
