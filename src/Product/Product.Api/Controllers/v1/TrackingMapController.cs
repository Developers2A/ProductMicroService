using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.Tracks.Queries.Track;
using ProductService.WebApi.Endpoint;

namespace ServiceProvider.Api.Controllers
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
