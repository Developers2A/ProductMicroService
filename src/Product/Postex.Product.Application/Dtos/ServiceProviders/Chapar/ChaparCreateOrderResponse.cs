using Newtonsoft.Json;
using System.Collections.Generic;

namespace Postex.Product.Application.Dtos.ServiceProviders.Chapar
{
    public class ChaparCreateOrderResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("objects")]
        public ChaparImport Objects { get; set; }
    }

    public class Result
    {
        [JsonProperty("tracking")]
        public string Tracking { get; set; }

        [JsonProperty("package")]
        public string[] Package { get; set; }

        [JsonProperty("reference")]
        public int Reference { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public class ChaparImport
    {
        [JsonProperty("result")]
        public List<Result> Result { get; set; }
    }
}
