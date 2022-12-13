using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.CollectionDistributions;
using Product.Application.Features.CourierCityTypePrices.Commands;
using Product.Application.Features.CourierCityTypePrices.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierCityTypePriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierCityTypePriceController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierCityTypePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierCityTypePriceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<ParcelCityDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetAllParcelCitiesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ParcelCityDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetParcelCityByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<BoxSizeDto>> GetByVolumeAndCityType([FromBody] GetParcelCitiesByVolumAndCityTypeQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
