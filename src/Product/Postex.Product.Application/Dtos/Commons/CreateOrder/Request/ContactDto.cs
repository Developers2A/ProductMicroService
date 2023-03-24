using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.CreateOrder.Request
{
    public class ContactDto
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("mobile_no")]
        public string Mobile { get; set; }

        [JsonPropertyName("telephone_no")]
        public string? Phone { get; set; }

        [JsonPropertyName("email_address")]
        public string? Email { get; set; }

        [JsonPropertyName("company_name")]
        public string? Company { get; set; }

        [JsonPropertyName("national_code")]
        public string? NationalCode { get; set; }
    }
}
