using Newtonsoft.Json;
using Postex.Product.Application.Dtos.ServiceProviders.Mahex.Common;

namespace Postex.Product.Application.Dtos.ServiceProviders.Mahex
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
