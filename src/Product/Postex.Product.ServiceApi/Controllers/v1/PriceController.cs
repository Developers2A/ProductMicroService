using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.Common.Queries.GetPrice;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetBasketPrices;
using Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPudoPrice;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice;
using Postex.Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices;
using Postex.Product.ServiceApi.Filters;
using Postex.SharedKernel.Api;

namespace Postex.Product.ServiceApi.Controllers.v1
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

        [HttpPost("online")]
        public async Task<ApiResult<GetPriceResponse>> GetOnlinePrice(GetPriceQuery request)
        {
            var result = await _mediator.Send(request);
            return new ApiResult<GetPriceResponse>(result.IsSuccess, result.Data, result.Message);
        }

        [HttpPost("offline")]
        public async Task<ApiResult<GetQuickPriceResponse>> GetOfflinePrice(GetOfflinePricesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("offline-price-collection")]
        public async Task<ApiResult<List<CourierCityTypePriceDto>>> GetOfflineCollectionDistributionPrice(GetCourierZoneCollectionDistributionPricesQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("fetch-offline-prices")]
        public async Task FetchOfflinePrices(CreateOfflineCourierZonePriceCommand createOfflineCourierZonePriceCommand)
        {
            await _mediator.Send(createOfflineCourierZonePriceCommand);
        }

        [HttpPost("basket-price")]
        public async Task<ApiResult<PriceResponseDto>> BasketPrice(BasketDto basket)
        {
            return await _mediator.Send(new GetBasketPricesQuery()
            {
                Basket = basket
            });
        }

        [HttpGet("pudo-price/{cityId}")]
        public async Task<ApiResult<PudoPriceResponseDto>> PudoPrice(int cityId)
        {
            var result = await _mediator.Send(new GetPudoPriceQuery()
            {
                CityId = cityId
            });
            return new ApiResult<PudoPriceResponseDto>(true, result);
        }
    }
}
