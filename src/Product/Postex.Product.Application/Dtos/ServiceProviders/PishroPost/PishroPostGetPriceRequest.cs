using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.PishroPost
{
    public class PishroPostGetPriceRequest
    {
        [JsonProperty("order")]
        public PishroPostOrder order { get; set; }
    }

    public class PishroPostOrder
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("method")]
        public int Method { get; set; }

        [JsonProperty("sender_code")]
        public int SenderCode { get; set; }

        [JsonProperty("receiver_code")]
        public string ReceiverCode { get; set; }

        [JsonProperty("cod")]
        public int COD { get; set; }
    }
}
