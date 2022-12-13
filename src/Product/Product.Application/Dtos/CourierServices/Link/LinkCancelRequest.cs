using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Link
{
    public class LinkCancelRequest
    {
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((TrackingCode ?? "").Trim()))
            {
                return new(false, "TrackingCode is required");
            }
            return (status, message);
        }
    }
}
