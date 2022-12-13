using Newtonsoft.Json;
using Product.Application.Dtos.CourierServices.Mahex.Common;

namespace Product.Application.Dtos.CourierServices.Mahex
{
    public class MahexCreateOrderResponse
    {
        public MahexCreateOrderResponse()
        {
            Data = new MahexOrderData();
            Status = new MahexStatus();
        }

        [JsonProperty("data")]
        public MahexOrderData Data { get; set; }

        [JsonProperty("status")]
        public MahexStatus Status { get; set; }

    }
}
