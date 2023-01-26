using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue;
using Postex.Product.Application.Features.CourierLimitValues.Commands.UpdateCourierLimitValue;
using Postex.Product.Application.Features.CourierLimitValues.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierLimitValueController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierLimitValueController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierLimitValueCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierLimitValueCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierLimitValueDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierLimitValuesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierLimitValueDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierLimitValueByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
