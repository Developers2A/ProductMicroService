﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Mahex.Common
{
    public class MahexOrderData
    {
        [JsonProperty("shipment_uuid")]
        public string ShipmentUuid { get; set; }
    }
}
