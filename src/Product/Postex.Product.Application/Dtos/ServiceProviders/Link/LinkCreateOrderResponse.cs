﻿using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Link
{
    public class LinkCreateOrderResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tracking_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("barcode_image_data")]
        public string BarcodeImageData { get; set; }
    }
}
