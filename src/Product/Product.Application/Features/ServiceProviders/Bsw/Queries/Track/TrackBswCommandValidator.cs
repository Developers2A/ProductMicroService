using FluentValidation;

namespace Product.Application.Features.ServiceProviders.Bsw.Queries.Track
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
