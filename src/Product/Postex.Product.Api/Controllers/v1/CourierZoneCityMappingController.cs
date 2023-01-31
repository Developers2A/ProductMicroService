using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierZoneCityMappings.Commands.CreateCourierZoneCityMapping;
using Postex.Product.Application.Features.CourierZoneCityMappings.Commands.UpdateCourierZoneCityMapping;
using Postex.Product.Application.Features.CourierZoneCityMappings.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierZoneCityMappingController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierZoneCityMappingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierZoneCityMappingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierZoneCityMappingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierZoneCityMappingDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneCityMappingsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierZoneCityMappingDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierZoneCityMappingByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
