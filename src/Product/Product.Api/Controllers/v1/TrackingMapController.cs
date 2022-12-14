using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.ServiceProviders.Common.Queries.Track;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class TrackingMapController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public TrackingMapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("track-map")]
        public async Task<ApiResult<TrackingMapResponse>> Track(GetTrackQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<TrackingMapResponse>(result.IsSuccess, result.Data, result.Message);
        }
    }
}
