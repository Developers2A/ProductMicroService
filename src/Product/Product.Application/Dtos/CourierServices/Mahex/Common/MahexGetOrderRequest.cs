﻿using Newtonsoft.Json;

namespace Product.Application.Dtos.Mahex.Common
{
    public class MahexGetOrderRequest
    {
        [JsonProperty("shipment_uuid")]
        public string ShipmentUuid { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((ShipmentUuid ?? "").Trim()))
            {
                status = false;
                message = "ShipmentUuid is required.";
            }
            return (status, message);
        }
    }
}
