using Newtonsoft.Json;
using Product.Application.Dtos.CourierServices.Mahex.Common;
using System.Collections.Generic;

namespace Product.Application.Dtos.CourierServices.Mahex
{
    public class MahexTrackResponse
    {
        public MahexTrackData Data { get; set; }
        public MahexStatus Status { get; set; }
    }

    public class MahexTrackData
    {
        [JsonProperty("waybill_number")]
        public string WaybillNumber { get; set; }

        [JsonProperty("uuid")]
        public string UUId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("create_date")]
        public string CreateDate { get; set; }

        [JsonProperty("update_date")]
        public string UpdateDate { get; set; }

        [JsonProperty("total_parts")]
        public int TotalParts { get; set; }

        [JsonProperty("current_state")]
        public string CurrentState { get; set; }

        [JsonProperty("parcels")]
        public List<MahexTrackParcel> Parcels { get; set; }
    }

    public class MahexTrackParcel
    {
        [JsonProperty("msgUuid")]
        public object MsgUuid { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contente")]
        public string Content { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("length")]
        public double Length { get; set; }

        [JsonProperty("current_location")]
        public string CurrentLocation { get; set; }

        [JsonProperty("current_state")]
        public string CurrentState { get; set; }
    }
}
