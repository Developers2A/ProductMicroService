﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffDeleteResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
