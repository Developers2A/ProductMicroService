using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierLimits.Commands.CreateCourierLimit;
using Postex.Product.Application.Features.CourierLimits.Commands.UpdateCourierLimit;
using Postex.Product.Application.Features.CourierLimits.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierLimitController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierLimitController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierLimitCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierLimitCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierLimitDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierLimitsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierLimitDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierLimitByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
