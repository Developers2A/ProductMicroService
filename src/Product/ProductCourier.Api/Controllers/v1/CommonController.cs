using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.Couriers.Queries;
using Product.Application.Features.ServiceProviders.Common.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Common.Queries.GetCities;
using Product.Application.Features.ServiceProviders.Common.Queries.GetPrice;
using Product.Application.Features.ServiceProviders.Common.Queries.GetStates;
using Product.Application.Features.ServiceProviders.Common.Queries.Track;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CommonController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("couriers")]
        public async Task<ApiResult<List<CourierDto>>> GetCouriers()
        {
            return await _mediator.Send(new GetCouriersQuery() { });
        }

        [HttpPost("states")]
        public async Task<ApiResult<List<CourierStateDto>>> GetStates(GetCourierStatesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("cities")]
        public async Task<ApiResult<List<CourierCityDto>>> GetCities(GetCourierCitiesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("price")]
        public async Task<ApiResult<GetPriceResponse>> Price(GetPriceQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<GetPriceResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("track")]
        public async Task<ApiResult<TrackingMapResponse>> Track(GetTrackQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<TrackingMapResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("create-order")]
        public async Task<ApiResult<CreateOrderResponse>> CreateOrder(CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CreateOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }
    }
}
