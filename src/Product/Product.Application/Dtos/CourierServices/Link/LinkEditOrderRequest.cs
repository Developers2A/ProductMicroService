using System;
using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Link
{
    public class LinkEditOrderRequest
    {
        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        [JsonProperty("companyTrackingCode")]
        public string CompanyTrackingCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("deliveryType")]
        public int DeliveryType { get; set; }

        [JsonProperty("sendDate")]
        public DateTime SendDate { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((TrackingCode ?? "").Trim()))
            {
                status = false;
                message += "TrackingCode is required. ";
            }

            if (string.IsNullOrEmpty((FullName ?? "").Trim()))
            {
                status = false;
                message += "FullName is required. ";
            }

            if (string.IsNullOrEmpty((CompanyTrackingCode ?? "").Trim()))
            {
                status = false;
                message += "CompanyTrackingCode is required. ";
            }

            if (SendDate.Date <= DateTime.Today.Date)
            {
                status = false;
                message += "SendDate must be greater than today. ";
            }
            if (string.IsNullOrEmpty((Address ?? "").Trim()))
            {
                status = false;
                message += "Address is required. ";
            }
            if (DeliveryType < 1 || DeliveryType > 5)
            {
                status = false;
                message += "DeliveryType should be 1,2,3,4,5. ";
            }

            return (status, message);
        }
    }
}
