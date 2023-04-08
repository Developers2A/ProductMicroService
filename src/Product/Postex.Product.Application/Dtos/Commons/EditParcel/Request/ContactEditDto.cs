using System.Text.Json.Serialization;

namespace Postex.Product.Application.Dtos.Commons.EditParcel.Request
{
    public class ContactEditDto
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

        [JsonPropertyName("national_code")]
        public string? NationalCode { get; set; }
    }
}
