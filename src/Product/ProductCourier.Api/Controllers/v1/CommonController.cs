using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.CollectionDistributions;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.Cities.Queries.GetCitiesCommon;
using Product.Application.Features.CourierCityTypePrices.Queries;
using Product.Application.Features.CourierServices.Queries;
using Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices;
using Product.Application.Features.ServiceProviders.Common.Commands.CreateOrder;
using Product.Application.Features.ServiceProviders.Common.Queries.GetPrice;
using Product.Application.Features.ServiceProviders.Common.Queries.Track;
using Product.Application.Features.States.Queries;

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
        public async Task<ApiResult<List<CourierCommonDto>>> GetCouriers()
        {
            return await _mediator.Send(new GetCouriersCommonQuery() { });
        }

        [HttpGet("states")]
        public async Task<ApiResult<List<StateCommonDto>>> GetStates()
        {
            return await _mediator.Send(new GetStatesCommonQuery());
        }

        [HttpPost("cities")]
        public async Task<ApiResult<List<CityCommonDto>>> GetCities(GetCitiesCommonQuery request)
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

        [HttpPost("cancel-order")]
        public async Task<ApiResult<CreateOrderResponse>> CancelOrder(CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CreateOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("offline-price-collection")]
        public async Task<ApiResult<List<CourierCityTypePriceDto>>> GetOfflineCollectionDistributionPrice(GetCourierCityTypePricesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("fetch-offline-prices")]
        public async Task FetchOfflinePrices()
        {
            await _mediator.Send(new CreateOfflineCourierZonePriceCommand());
        }

        [HttpPost("offline-price")]
        public async Task GetOfflinePrice(GetOfflinePricesQuery request)
        {
            await _mediator.Send(request);
        }
    }
}
