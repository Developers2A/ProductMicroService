using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class ValueAddedServiceResponseDto
    {
        [JsonProperty("value_type_id")]
        public int ValueTypeId { get; set; }

        [JsonProperty("value_type_name")]
        public string ValueTypeName { get; set; }

        [JsonProperty("buy_price")]
        public int BuyPrice { get; set; }

        [JsonProperty("sale_price")]
        public int SalePrice { get; set; }

        [JsonProperty("contract_id")]
        public int ContractId { get; set; }

        [JsonProperty("contract_detail_id")]
        public int ContractDetailId { get; set; }
    }
}
