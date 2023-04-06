using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class CreateParcelResponseDto
    {
        [JsonPropertyName("is_oversized")]
        public bool IsOversized { get; set; }

        [JsonPropertyName("additional_data")]
        public AdditionalDataResponseDto AdditionalData { get; set; }

        [JsonPropertyName("service_category")]
        public string ServiceCategory { get; set; }

        [JsonPropertyName("shipments")]
        public List<ShipmentResponseDto> Shipments { get; set; }

        [JsonPropertyName("value_added_services")]
        public List<ValueAddedServiceResponseDto> ValueAddedService { get; set; }
    }
}
