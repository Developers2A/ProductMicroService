using FluentValidation;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.Track
{
    public class GetTaroffTrackQueryValidator : AbstractValidator<GetTaroffTrackQuery>
    {
        public GetTaroffTrackQueryValidator()
        {
            RuleFor(p => p.OrderId)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage(" شناسه سفارش الزامی میباشد");
        }
    }
}
