﻿using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Speed
{
    public class SpeedCreateOrderResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("barcode")]
        public long Barcode { get; set; }

        [JsonProperty("payable")]
        public int Payable { get; set; }
    }
}
