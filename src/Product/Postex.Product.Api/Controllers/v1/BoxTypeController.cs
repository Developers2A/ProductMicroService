using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.BoxTypes.Commands.CreateBoxType;
using Postex.Product.Application.Features.BoxTypes.Commands.DeleteBoxType;
using Postex.Product.Application.Features.BoxTypes.Commands.UpdateBoxType;
using Postex.Product.Application.Features.BoxTypes.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class BoxTypeController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public BoxTypeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateBoxTypeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateBoxTypeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] DeleteBoxTypeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<BoxPriceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetBoxTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<BoxPriceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetBoxTypeByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
