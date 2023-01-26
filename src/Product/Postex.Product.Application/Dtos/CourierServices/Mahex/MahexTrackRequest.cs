using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Mahex
{
    public class MahexTrackRequest
    {
        [JsonProperty("waybill_number")]
        public string WaybillNumber { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("part_number")]
        public string PartNumber { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((WaybillNumber ?? "").Trim()) &&
                  string.IsNullOrEmpty((Reference ?? "").Trim()) &&
                  string.IsNullOrEmpty((PartNumber ?? "").Trim()))
            {
                status = false;
                message = "waybill_number and reference and part_number is null";
            }
            return (status, message);
        }
    }
}
