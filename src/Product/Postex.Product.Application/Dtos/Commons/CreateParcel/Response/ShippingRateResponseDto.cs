using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateParcel.Response
{
    public class ShippingRateResponseDto
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("discount")]
        public int Discount { get; set; }

        [JsonPropertyName("vat")]
        public int Vat { get; set; }

        [JsonPropertyName("sale_price")]
        public int SalePrice { get; set; }

        [JsonPropertyName("buy_price")]
        public int BuyPrice { get; set; }

        [JsonPropertyName("post_price")]
        public PostPriceResponseDto PostPrice { get; set; }
    }
}
