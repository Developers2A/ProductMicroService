using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetDistributionAndCollectionPrices
{
    public class GetDistributionAndCollectionPricesQuery : IRequest<PriceResponseDto>
    {
        public Basket Basket { get; set; }
        public List<CollectionDistributionPriceDto> CollectionDistributionPrices { get; set; }
    }
}