using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance;
using Postex.Product.Application.Features.CourierInsurances.Commands.UpdateCourierInsurance;
using Postex.Product.Application.Features.CourierInsurances.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierInsuranceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierInsuranceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierInsuranceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierInsuranceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierInsuranceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierInsurancesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierInsuranceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierInsuranceByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
