using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.CourierServices.Commands.CreateCourierService;
using Product.Application.Features.CourierServices.Commands.DeleteCourierService;
using Product.Application.Features.CourierServices.Commands.UpdateCourierService;
using Product.Application.Features.CourierServices.Queries.GetCourierServiceById;
using Product.Application.Features.CourierServices.Queries.GetCourierServices;

namespace Product.Api.Controllers.v1
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

        [HttpDelete]
        public async Task<ApiResult> Delete([FromBody] DeleteCourierServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierServiceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServicesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierServiceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServiceByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
