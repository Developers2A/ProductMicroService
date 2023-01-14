using MediatR;
using Postex.SharedKernel.Common.Enums;
using Product.Application.Dtos.CollectionDistributions;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.CourierCityTypePrices.Queries.GetBasketPrices
{
    public class GetBasketPricesQuery : IRequest<GetPriceResponse>
    {
        public List<ParcelPrice> Parcels { get; set; }
        public CityTypeCode CityTypeId { get; set; }
        public ServiceType ServiceId { get; set; }
        public CourierCode CourierId { get; set; }
        public string BasketId { get; set; }
    }
}