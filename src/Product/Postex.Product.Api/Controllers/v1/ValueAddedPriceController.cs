using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.ValueAddedPrices.Commands.CreateValueAddedPrice;
using Postex.Product.Application.Features.ValueAddedPrices.Commands.DeleteValueAddedPrice;
using Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice;
using Postex.Product.Application.Features.ValueAddedPrices.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ValueAddedPriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ValueAddedPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateValueAddedPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateValueAddedPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] DeleteValueAddedPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<ValueAddedPriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetValueAddedPricesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ValueAddedPriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetValueAddedPriceByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
