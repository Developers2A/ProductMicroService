using MediatR;
using Product.Application.Dtos.CollectionDistributionPrices.Basket;

namespace Product.Application.Features.CourierCityTypePrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQuery : IRequest<PriceResponseDto>
    {
        public Basket Basket { get; set; }
    }
}