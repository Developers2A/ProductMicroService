using Newtonsoft.Json;
using System.Collections.Generic;

namespace Postex.Product.Application.Dtos.ServiceProviders.PishroPost
{
    public class PishroPostTrackResponse
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("objects")]
        public PishroPostTrackResponseObject Objects { get; set; }
    }

    public class PishroPostTrackPriceResponse
    {
        [JsonProperty("shipping")]
        public string Shipping { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("packing")]
        public string Packing { get; set; }

        [JsonProperty("extra_shipping_origin")]
        public string ExtraShippingOrigin { get; set; }

        [JsonProperty("extra_shipping_destination")]
        public string ExtraShippingDestination { get; set; }

        [JsonProperty("insurance")]
        public string Insurance { get; set; }

        [JsonProperty("fuel")]
        public string Fuel { get; set; }

        [JsonProperty("vat")]
        public string Vat { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }

    public class PishroPostTrackOrderResponse
    {
        [JsonProperty("delivered_to")]
        public string DeliveredTo { get; set; }

        [JsonProperty("delivery_time")]
        public string DeliveryTime { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        [JsonProperty("history")]
        public List<PishroPostTrackHistoryResponse> History { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("dest")]
        public string Dest { get; set; }

        [JsonProperty("reference")]
        public object Reference { get; set; }

        [JsonProperty("third_reference")]
        public object ThirdReference { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("price")]
        public PishroPostTrackPriceResponse Price { get; set; }
    }

    public class PishroPostTrackHistoryResponse
    {
        [JsonProperty("attach")]
        public string Attach { get; set; }

        [JsonProperty("timestamp_date")]
        public int TimestampDate { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        [JsonProperty("loc")]
        public object Loc { get; set; }
    }

    public class PishroPostTrackResponseObject
    {
        [JsonProperty("order")]
        public PishroPostTrackOrderResponse Order { get; set; }
    }

    public class Geo
    {
        [JsonProperty("lat")]
        public object Lat { get; set; }

        [JsonProperty("lng")]
        public object Lng { get; set; }
    }
}
