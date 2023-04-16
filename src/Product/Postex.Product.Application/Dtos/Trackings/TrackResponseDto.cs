using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Trackings
{
    public class TrackResponseDto
    {
        /// <summary>
        /// کد وضعیت کوریر
        /// </summary>
        [JsonPropertyName("courier_status_code")]
        public string CourierStatusCode { get; set; }

        /// <summary>
        /// شرح وضعیت کوریر
        /// </summary>
        [JsonPropertyName("courier_status")]
        public string CourierStatus { get; set; }

        /// <summary>
        /// کد پنج رقمی وضعیت پستکس
        /// </summary>

        [JsonPropertyName("postex_status_code")]
        public string PostexStatusCode { get; set; }

        /// <summary>
        /// شرح وضعیت پستکس
        /// </summary>
        [JsonPropertyName("postex_status")]
        public string PostexStatus { get; set; }

        /// <summary>
        /// تاریخ وضعیت
        /// </summary>
        [JsonPropertyName("update_date")]
        public string UpdateDate { get; set; }
    }
}
