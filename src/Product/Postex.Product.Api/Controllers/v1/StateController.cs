using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Features.States.Commands.CreateState;
using Postex.Product.Application.Features.States.Commands.UpdateState;
using Postex.Product.Application.Features.States.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class StateController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateStateCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateStateCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<StateDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetStatesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<StateDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetStateByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
