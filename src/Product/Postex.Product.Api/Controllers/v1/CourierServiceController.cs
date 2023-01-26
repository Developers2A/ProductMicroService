using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService;
using Postex.Product.Application.Features.CourierServices.Commands.UpdateCourierService;
using Postex.Product.Application.Features.CourierServices.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierServiceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierServiceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServicesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServiceByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
