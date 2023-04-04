using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetCollectionPrices
{
    public class GetCollectionPricesQuery : IRequest<PriceResponseDto>
    {
        public BasketDto Basket { get; set; }
        public List<CollectionDistributionPriceDto> CollectionDistributionPrices { get; set; }
    }
}