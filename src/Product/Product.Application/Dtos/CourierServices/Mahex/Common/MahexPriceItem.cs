﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Mahex.Common
{
    public class MahexPriceItem
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
