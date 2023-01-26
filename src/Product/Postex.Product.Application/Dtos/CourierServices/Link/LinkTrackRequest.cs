using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Link
{
    public class LinkTrackRequest
    {
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((TrackingCode ?? "").Trim()))
            {
                status = false;
                message = "TrackingCode is required.";
            }
            return (status, message);
        }
    }
}
