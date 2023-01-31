using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostTrackRequest
    {
        [JsonProperty("order")]
        public PishroPostTrackOrder Order { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((Order.Reference ?? "").Trim()))
            {
                return new(false, "reference is required");
            }
            return (status, message);
        }
    }

    public class PishroPostTrackOrder
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; } = "fa";
    }
}
