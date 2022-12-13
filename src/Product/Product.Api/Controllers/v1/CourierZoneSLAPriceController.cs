using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.CourierZoneSLAPrices.Commands.CreateCourierZoneSLAPrice;
using Product.Application.Features.CourierZoneSLAPrices.Commands.UpdateCourierZoneSLAPrice;
using Product.Application.Features.CourierZoneSLAPrices.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierZoneSLAPriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierZoneSLAPriceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierZoneSLAPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierZoneSLAPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierZoneSLAPriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneSLAPricesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierZoneSLAPriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneSLAPriceByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
