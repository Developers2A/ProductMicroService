using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Commands.UpdateCourierZonePrice;
using Product.Application.Features.CourierZonePrices.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierZonePriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierZonePriceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierZonePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierZonePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierZonePriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZonePricesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierZonePriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServiceZonePriceByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
