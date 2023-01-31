using Newtonsoft.Json;
using Postex.Product.Application.Dtos.CourierServices.Mahex.Common;

namespace Postex.Product.Application.Dtos.CourierServices.Mahex
{
    public class MahexGetPriceResponse
    {
        public MahexGetPriceResponse()
        {
            Data = new MahexRateData();
            Status = new MahexStatus();
        }

        [JsonProperty("data")]
        public MahexRateData Data { get; set; }

        [JsonProperty("status")]
        public MahexStatus Status { get; set; }

    }
    public class MahexRateData
    {
        public MahexRateData()
        {
            Rate = new MahexRate();
        }

        [JsonProperty("rate")]
        public MahexRate Rate { get; set; }

        [JsonProperty("delivery_window")]
        public string DeliveryWindow { get; set; }
    }

    public class MahexRate
    {
        [JsonProperty("product")]
        public MahexProduct Product { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
