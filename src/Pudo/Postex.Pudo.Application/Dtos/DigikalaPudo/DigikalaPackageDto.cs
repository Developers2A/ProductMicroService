using Newtonsoft.Json;

namespace Postex.Pudo.Application.Dtos.DigikalaPudo
{
    public class DigikalaPackageDto
    {
        [JsonProperty("packages")]
        public List<DigikalaPudoPackage> Packages { get; set; }

        [JsonProperty("rows_on_page")]
        public int RowsOnPage { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }

    public class BoxSize
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("depth")]
        public int Depth { get; set; }
    }

    public class DigikalaPudoPackage
    {
        [JsonProperty("package")]
        public DigikalaPudoPackage Package { get; set; }

        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }

        [JsonProperty("promised_at")]
        public PromisedAt PromisedAt { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("box_size")]
        public BoxSize BoxSize { get; set; }

        [JsonProperty("total_price")]
        public int TotalPrice { get; set; }

        public int PudoPrice { get; set; }
    }

    public class Product
    {
        [JsonProperty("item_title")]
        public string item_title { get; set; }

        [JsonProperty("item_price")]
        public int item_price { get; set; }

        [JsonProperty("item_category")]
        public string item_category { get; set; }
    }

    public class PromisedAt
    {
        [JsonProperty("item_category")]
        public string Date { get; set; }

        [JsonProperty("item_category")]
        public int TimeFrom { get; set; }

        [JsonProperty("item_category")]
        public int TimeTo { get; set; }
    }

    public class Receiver
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonProperty("building_number")]
        public string BuildingNumber { get; set; }

        [JsonProperty("building_unit")]
        public string BuildingUnit { get; set; }

        [JsonProperty("nature")]
        public string Nature { get; set; }

        [JsonProperty("address_area")]
        public string AddressArea { get; set; }
    }
}
