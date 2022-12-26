using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.CollectionDistributions;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.Common.Commands.CancelOrder;
using Product.Application.Features.Common.Commands.CreateOrder;
using Product.Application.Features.Common.Commands.DeleteOrder;
using Product.Application.Features.Common.Commands.ReadyOrder;
using Product.Application.Features.Common.Queries.GetPrice;
using Product.Application.Features.Common.Queries.Track;
using Product.Application.Features.CourierCityTypePrices.Queries;
using Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices;

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
        public async Task<ApiResult<CancelOrderResponse>> CancelOrder(CancelOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CancelOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("ready-order")]
        public async Task<ApiResult<ReadyOrderResponse>> ReadyOrder(ReadyOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<ReadyOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("delete-order")]
        public async Task<ApiResult<DeleteOrderResponse>> DeleteOrder(DeleteOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<DeleteOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("price")]
        public async Task<ApiResult<GetPriceResponse>> Price(GetPriceQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<GetPriceResponse>(result.IsSuccess, result.Data, result.Message);
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
        public async Task<ApiResult<GetPriceResponse>> GetOfflinePrice(GetOfflinePricesQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
