using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.CourierZoneSLAs.Commands.CreateCourierZoneSLA;
using Product.Application.Features.CourierZoneSLAs.Commands.UpdateCourierZoneSLA;
using Product.Application.Features.CourierZoneSLAs.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierZoneSLAController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierZoneSLAController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierZoneSLACommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierZoneSLACommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierZoneSLADto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneSLAsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierZoneSLADto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneSLAByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
