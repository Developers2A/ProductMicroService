using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.ServiceProviders.Link
{
    public class LinkTrackResponse
    {
        [JsonProperty("result")]
        public LinkTrackResult Result { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }


    public class LinkTrackResult
    {
        [JsonProperty("deliveryCode")]
        public string DeliveryCode { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("doneDate")]
        public DateTime? DoneDate { get; set; }

        [JsonProperty("actualReceiverName")]
        public string ActualReceiverName { get; set; }

        [JsonProperty("failRejectReasonTitle")]
        public string FailRejectReasonTitle { get; set; }

        [JsonProperty("failRejectReasonDescription")]
        public string FailRejectReasonDescription { get; set; }

        [JsonProperty("paymentMethod")]
        public int PaymentMethod { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("paidAt")]
        public DateTime? PaidAt { get; set; }

        [JsonProperty("refNumber")]
        public int? RefNumber { get; set; }

        [JsonProperty("signatureUrl")]
        public string SignatureUrl { get; set; }

        [JsonProperty("ptrackingcode")]
        public string PTrackingCode { get; set; }

        [JsonProperty("fee")]
        public decimal? Fee { get; set; }
    }
}
