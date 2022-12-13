﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffGetCityResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("categories")]
        public List<TaroffState> Categories { get; set; }
    }
}
