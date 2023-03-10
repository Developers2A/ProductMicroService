using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class ContactDto
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("mobile_no")]
        public string Mobile { get; set; }

        [JsonProperty("telephone_no")]
        public string? Phone { get; set; }

        [JsonProperty("email_address")]
        public string? Email { get; set; }

        [JsonProperty("company_name")]
        public string? Company { get; set; }

        [JsonProperty("national_code")]
        public string? NationalCode { get; set; }
    }
}
