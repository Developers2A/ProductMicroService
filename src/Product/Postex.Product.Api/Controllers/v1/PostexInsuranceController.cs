using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance;
using Postex.Product.Application.Features.PostexInsurances.Commands.UpdatePostexInsurance;
using Postex.Product.Application.Features.PostexInsurances.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class PostexInsuranceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public PostexInsuranceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreatePostexInsuranceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdatePostexInsuranceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<PostexInsuranceDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetPostexInsurancesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<PostexInsuranceDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetPostexInsuranceByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
