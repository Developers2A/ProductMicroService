using Postex.SharedKernel.Common.Enums;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket
{
    public class BasketDto
    {
        public List<BoxPrice> Parcels { get; set; }

        [JsonPropertyName("city_type")]
        public CityTypeCode CityTypeCode { get; set; }

        [JsonPropertyName("service_type")]
        public ServiceType ServiceType { get; set; }

        [JsonPropertyName("courier_code")]
        public CourierCode CourierCode { get; set; }
        public string BasketId { get; set; }

        public BasketDto()
        {
            Parcels = new List<BoxPrice>();
        }
    }
}