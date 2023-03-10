using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class CreateOrderResponseDto
    {
        [JsonProperty("is_oversized")]
        public bool IsOversized { get; set; }

        [JsonProperty("additional_data")]
        public AdditionalDataResponseDto AdditionalData { get; set; }

        [JsonProperty("service_category")]
        public string ServiceCategory { get; set; }

        [JsonProperty("shipments")]
        public List<ShipmentResponseDto> Shipments { get; set; }

        [JsonProperty("value_added_services")]
        public List<ValueAddedServiceResponseDto> ValueAddedService { get; set; }
    }
}
