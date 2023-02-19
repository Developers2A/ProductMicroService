using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Pudo.Application.Dtos.DigikalaPudo;
using Postex.Pudo.Application.Features.DigikalaPudoPrice.Queries.DigikalaPudoPrices;
using Postex.SharedKernel.Api;

namespace Postex.Pudo.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class PriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("digikala-pudo-price")]
        public async Task<ApiResult<DigikalaPackageDto>> GetDigikalaPudoPrice(GetDigikalaPudoPricesQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<DigikalaPackageDto>(result.IsSuccess, result.Data, result.Message);
        }
    }
}
