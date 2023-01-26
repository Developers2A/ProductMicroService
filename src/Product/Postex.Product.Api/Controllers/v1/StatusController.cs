using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Features.Statuses.Commands.CreateStatus;
using Postex.Product.Application.Features.Statuses.Commands.UpdateStatus;
using Postex.Product.Application.Features.Statuses.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class StatusController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<StatusDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetStatusesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<StatusDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetStatusByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
