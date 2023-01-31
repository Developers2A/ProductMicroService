using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice;
using Postex.Product.Application.Features.BoxPrices.Commands.DeleteBoxPrice;
using Postex.Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice;
using Postex.Product.Application.Features.BoxPrices.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class BoxPriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public BoxPriceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateBoxPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateBoxPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] DeleteBoxPriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<BoxPriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetBoxPricesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<BoxPriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetBoxPriceByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
