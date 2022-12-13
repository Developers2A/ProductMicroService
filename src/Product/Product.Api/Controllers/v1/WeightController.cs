using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Commons;
using Product.Application.Features.Weights.Commands.CreateWeight;
using Product.Application.Features.Weights.Commands.UpdateWeight;
using Product.Application.Features.Weights.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class WeightController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public WeightController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateWeightCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateWeightCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<WeightDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetWeightsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<WeightDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetWeightByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
