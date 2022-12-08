using Newtonsoft.Json;

namespace Product.Application.Dtos.Mahex.Common
{
    public class MahexStatus
    {
        [JsonProperty("code")]
        public decimal Code { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("invalid_field")]
        public string InvalidField { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
