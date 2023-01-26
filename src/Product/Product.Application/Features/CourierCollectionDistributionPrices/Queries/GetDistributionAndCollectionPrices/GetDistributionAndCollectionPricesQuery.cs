using MediatR;
using Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Product.Application.Dtos.CollectionDistributions;

namespace Product.Application.Features.CourierCityTypePrices.Queries.GetDistributionAndCollectionPrices
{
    public class GetDistributionAndCollectionPricesQuery : IRequest<PriceResponseDto>
    {
        public Basket Basket { get; set; }
        public List<CollectionDistributionPriceDto> CollectionDistributionPrices { get; set; }
    }
}