using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.SLAs.Commands.CreateSLA;
using Product.Application.Features.SLAs.Commands.DeleteSLA;
using Product.Application.Features.SLAs.Commands.UpdateSLA;
using Product.Application.Features.SLAs.Queries.GetSLAById;
using Product.Application.Features.SLAs.Queries.GetSLAs;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class SLAController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public SLAController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateSLACommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateSLACommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] DeleteSLACommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<SLADto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetSLAsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SLADto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetSLAByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
