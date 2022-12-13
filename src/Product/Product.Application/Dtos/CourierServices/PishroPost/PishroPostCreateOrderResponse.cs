using Newtonsoft.Json;
using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostCreateOrderObject
    {
        [JsonProperty("result")]
        public List<PishroPostCreateResult> Result { get; set; }
    }

    public class PishroPostCreateResult
    {
        [JsonProperty("tracking")]
        public string Tracking { get; set; }

        [JsonProperty("package")]
        public string Package { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public class PishroPostCreateOrderResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("objects")]
        public PishroPostCreateOrderObject Objects { get; set; }
    }
}
