using FluentValidation;

namespace Product.Application.Features.CourierServices.Speed.Queries.Track
{
    public class GetSpeedTrackQueryValidator : AbstractValidator<GetSpeedTrackQuery>
    {
        public GetSpeedTrackQueryValidator()
        {
        }
    }
}
