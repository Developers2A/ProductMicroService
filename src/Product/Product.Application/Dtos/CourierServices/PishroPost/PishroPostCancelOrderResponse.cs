using Newtonsoft.Json;
using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostCancelOrderResponseObject
    {
        [JsonProperty("order")]
        public List<object> Order { get; set; }
    }

    public class PishroPostCancelOrderResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("objects")]
        public PishroPostCancelOrderResponseObject Objects { get; set; }
    }
}
