using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQuery : IRequest<PriceResponseDto>
    {
        public Basket Basket { get; set; }
    }
}