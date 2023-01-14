using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Api.Filters;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Dtos.Trackings;
using Product.Application.Features.Common.Commands.CancelOrder;
using Product.Application.Features.Common.Commands.CreateOrder;
using Product.Application.Features.Common.Commands.DeleteOrder;
using Product.Application.Features.Common.Commands.EditOrder;
using Product.Application.Features.Common.Commands.EditWeight;
using Product.Application.Features.Common.Commands.ReadyOrder;
using Product.Application.Features.Common.Queries.Track;

namespace Product.Api.Controllers.v1
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
        public async Task<ApiResult<CreateOrderResponse>> CreateOrder(CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CreateOrderResponse>(result.IsSuccess, result.Data, result.Message);
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
