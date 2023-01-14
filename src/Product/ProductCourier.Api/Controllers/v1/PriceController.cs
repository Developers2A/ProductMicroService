using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Api.Filters;
using Product.Application.Dtos.CollectionDistributions;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.Common.Queries.GetPrice;
using Product.Application.Features.CourierCityTypePrices.Queries;
using Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [ApiKey]
    public class PriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("online-price")]
        public async Task<ApiResult<GetPriceResponse>> GetOnlinePrice(GetPriceQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<GetPriceResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("offline-price")]
        public async Task<ApiResult<GetPriceResponse>> GetOfflinePrice(GetOfflinePricesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("offline-price-collection")]
        public async Task<ApiResult<List<CourierCityTypePriceDto>>> GetOfflineCollectionDistributionPrice(GetCourierZoneCollectionDistributionPricesQuery request)
        {
            return await _mediator.Send(request);
        }

        //[HttpGet("fetch-offline-prices")]
        //public async Task FetchOfflinePrices()
        //{
        //    await _mediator.Send(new CreateOfflineCourierZonePriceCommand());
        //}


    }
}
