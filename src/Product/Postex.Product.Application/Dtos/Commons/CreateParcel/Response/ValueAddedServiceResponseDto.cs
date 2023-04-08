using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Response
{
    public class ValueAddedServiceResponseDto
    {
        [JsonPropertyName("value_type_id")]
        public int ValueTypeId { get; set; }

        [JsonPropertyName("value_type_name")]
        public string ValueTypeName { get; set; }

        [JsonPropertyName("buy_price")]
        public int BuyPrice { get; set; }

        [JsonPropertyName("sale_price")]
        public int SalePrice { get; set; }

        [JsonPropertyName("contract_id")]
        public int ContractId { get; set; }

        [JsonPropertyName("contract_detail_id")]
        public int ContractDetailId { get; set; }
    }
}
