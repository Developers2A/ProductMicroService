using Newtonsoft.Json;

namespace Product.Application.Dtos.CourierServices.Taroff.Dtos
{
    public class TaroffTrackResponse
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("barcode")]
        public object Barcode { get; set; }

        [JsonProperty("stateid")]
        public int StateId { get; set; }

        [JsonProperty("statetitle")]
        public string StateTitle { get; set; }

        [JsonProperty("shopshare")]
        public object ShopShare { get; set; }

        [JsonProperty("taroffshare")]
        public object TroffShare { get; set; }

        [JsonProperty("postshare")]
        public object PostShare { get; set; }

        [JsonProperty("peikname")]
        public object PeikName { get; set; }

        [JsonProperty("peikphone")]
        public object PeikPhone { get; set; }
    }
}
