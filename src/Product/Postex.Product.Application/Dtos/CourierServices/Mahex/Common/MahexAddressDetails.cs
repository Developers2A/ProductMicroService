using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Mahex.Common
{
    public class MahexAddressDetails
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; }

        [JsonProperty("national_id")]
        public string NationalId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }
    }
}
