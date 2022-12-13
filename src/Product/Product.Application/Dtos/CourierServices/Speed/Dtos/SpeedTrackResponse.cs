﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedTrackResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("result-json")]
        public string[] ResultJson { get; set; }

    }

}
