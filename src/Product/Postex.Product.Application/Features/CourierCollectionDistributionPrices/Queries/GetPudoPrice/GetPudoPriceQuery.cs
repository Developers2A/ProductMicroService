using MediatR;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPudoPrice
{
    public class GetPudoPriceQuery : IRequest<PudoPriceResponseDto>
    {
        public int CityId { get; set; }
    }
}