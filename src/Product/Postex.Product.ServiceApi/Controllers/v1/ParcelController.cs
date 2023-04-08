using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Dtos.Trackings;
using Postex.Product.Application.Features.Common.Commands.CancelParcel;
using Postex.Product.Application.Features.Common.Commands.CreateParcel;
using Postex.Product.Application.Features.Common.Commands.DeleteParcel;
using Postex.Product.Application.Features.Common.Commands.EditParcel;
using Postex.Product.Application.Features.Common.Commands.EditWeight;
using Postex.Product.Application.Features.Common.Commands.ReadyParcel;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrackingMapResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> Track(
            int courierCode,
            string trackCode,
            [FromHeader(Name = "x-correlation-id")] Guid correlationId,
            [FromHeader(Name = "x-user-id")] Guid userId)
        {
            var result = await _mediator.Send(new GetTrackQuery()
            {
                CourierCode = courierCode,
                TrackCode = trackCode
            });

            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(new ApiResult(false, result.Message));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ParcelResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> Create(
            [FromBody] CreateParcelCommand request,
            [FromHeader(Name = "x-correlation-id")] Guid correlationId,
            [FromHeader(Name = "x-user-id")] Guid userId)
        {
            request.UserID = userId;
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(new ApiResult(false, result.Message));
        }

        [HttpPut("edit-weight")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ParcelResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResult))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> EditWeight(
            [FromBody] EditWeightCommand request,
            [FromHeader(Name = "x-correlation-id")] Guid correlationId,
            [FromHeader(Name = "x-user-id")] Guid userId)
        {
            request.UserID = userId;
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(new ApiResult(false, result.Message));
        }

        [HttpPut]
        public async Task<ApiResult<EditParcelResponse>> Edit(
            [FromBody] EditParcelCommand request,
            [FromHeader(Name = "x-correlation-id")] Guid correlationId,
            [FromHeader(Name = "x-user-id")] Guid userId)
        {
            request.UserID = User;
            var result = await _mediator.Send(request);
            return new ApiResult<EditParcelResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("cancel")]
        public async Task<ApiResult<CancelParcelResponse>> Cancel(CancelParcelCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<CancelParcelResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("ready")]
        public async Task<ApiResult<ReadyParcelResponse>> Ready(ReadyParcelCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<ReadyParcelResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpDelete]
        public async Task<ApiResult<DeleteParcelResponse>> Delete(DeleteParcelCommand request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<DeleteParcelResponse>(result.IsSuccess, result.Data, result.Message);
        }
    }
}
