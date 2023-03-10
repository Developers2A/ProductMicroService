using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Response
{
    public class ShippingRateResponseDto
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }

        [JsonProperty("vat")]
        public int Vat { get; set; }

        [JsonProperty("sale_price")]
        public int SalePrice { get; set; }

        [JsonProperty("buy_price")]
        public int BuyPrice { get; set; }

        [JsonProperty("post_price")]
        public PostPriceResponseDto PostPrice { get; set; }
    }
}
