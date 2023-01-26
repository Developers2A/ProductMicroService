using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Features.Zones.Commands.CreateZone;
using Postex.Product.Application.Features.Zones.Commands.UpdateZone;
using Postex.Product.Application.Features.Zones.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ZoneController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ZoneController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateZoneCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateZoneCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<ZoneDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetZonesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ZoneDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetZoneByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
