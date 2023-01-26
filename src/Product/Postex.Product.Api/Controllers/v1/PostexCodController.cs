using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Features.PostexCods.Commands.CreatePostexCod;
using Postex.Product.Application.Features.PostexCods.Commands.UpdatePostexCod;
using Postex.Product.Application.Features.PostexCods.Queries;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class PostexCodController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public PostexCodController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreatePostexCodCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdatePostexCodCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<PostexCodDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetPostexCodsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<PostexCodDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetPostexCodByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
