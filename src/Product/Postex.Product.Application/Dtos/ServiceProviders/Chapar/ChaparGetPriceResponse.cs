using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar
{
    public class ChaparGetPriceResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("objects")]
        public ObjectsGetQuote Objects { get; set; }
    }

    public class OrderGetQuote
    {
        [JsonProperty("quote")]
        public decimal Quote { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("price")]
        public ChaparPrice Price { get; set; }
    }
    public class ObjectsGetQuote
    {
        [JsonProperty("order")]
        public OrderGetQuote Order { get; set; }
    }
    public class ChaparPrice
    {
        public string Zone { get; set; }
        public int fld_Manual_Cost { get; set; }
        public int fld_Pack_Cost { get; set; }
        public int fld_Charge_Cost { get; set; }
        public int fld_Manual_Insurance { get; set; }
        public int fld_Lab_Cost { get; set; }
        public int fld_Manual_VAT { get; set; }
        public int fld_Total_Cost { get; set; }
        public string price_list { get; set; }
        public string min_ins { get; set; }
    }
}
