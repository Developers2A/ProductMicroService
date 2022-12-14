using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.CourierServiceZonePrices.Commands.CreateCourierServiceZonePrice;
using Product.Application.Features.CourierServiceZonePrices.Commands.UpdateCourierServiceZonePrice;
using Product.Application.Features.CourierServiceZonePrices.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierServiceZonePriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierServiceZonePriceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierServiceZonePricePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierServiceZonePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierServiceZonePriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServiceZonePricesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierServiceZonePriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServiceZonePriceByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
