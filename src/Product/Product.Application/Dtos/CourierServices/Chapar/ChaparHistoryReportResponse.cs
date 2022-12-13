using Newtonsoft.Json;
using Product.Application.Dtos.CourierServices.Chapar.Common;
using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.Chapar
{
    public class ChaparHistoryReportResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("objects")]
        public ChaparReportObject Objects { get; set; }
    }

    public class ChaparReportObject
    {
        [JsonProperty("history")]
        public List<ChaparHistory> History { get; set; }
    }
}
