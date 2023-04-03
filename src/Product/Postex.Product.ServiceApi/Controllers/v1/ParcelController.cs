using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.Trackings;
using Postex.Product.Application.Features.Common.Commands.CancelOrder;
using Postex.Product.Application.Features.Common.Commands.CreateOrder;
using Postex.Product.Application.Features.Common.Commands.DeleteOrder;
using Postex.Product.Application.Features.Common.Commands.EditOrder;
using Postex.Product.Application.Features.Common.Commands.EditWeight;
using Postex.Product.Application.Features.Common.Commands.ReadyOrder;
using Postex.Product.Application.Features.Common.Queries.Track;
using Postex.Product.ServiceApi.Filters;
using Postex.SharedKernel.Api;

namespace Postex.Product.ServiceApi.Controllers.v1
{
    [ApiVersion("1")]
    [ApiKey]
    public class ParcelController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ParcelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("track")]
        public async Task<ApiResult<TrackingMapResponse>> Track(int courierCode, string trackCode)
        {
            var result = await _mediator.Send(new GetTrackQuery()
            {
                CourierCode = courierCode,
                TrackCode = trackCode
            });
            return new ApiResult<TrackingMapResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost]
        public async Task<ApiResult<CreateOrderResponseDto>> CreateOrder(CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CreateOrderResponseDto>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPut]
        public async Task<ApiResult<EditOrderResponse>> EditOrder(EditOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<EditOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("cancel")]
        public async Task<ApiResult<CancelOrderResponse>> CancelOrder(CancelOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CancelOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("ready")]
        public async Task<ApiResult<ReadyOrderResponse>> ReadyOrder(ReadyOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<ReadyOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpDelete]
        public async Task<ApiResult<DeleteOrderResponse>> DeleteOrder(DeleteOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<DeleteOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPut("edit-weight")]
        public async Task<ApiResult<EditOrderResponse>> EditWeight(EditWeightCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<EditOrderResponse>(result.IsSuccess, result.Data, result.Message);
        }
    }
}
