﻿using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk
{
    public class EcoPeykOrderResponse
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class EcoPeykCreateOrderResponse
    {
        [JsonProperty("requestId")]
        public int RequestId { get; set; }

        [JsonProperty("orders")]
        public List<EcoPeykOrderResponse> Orders { get; set; }
    }
}
