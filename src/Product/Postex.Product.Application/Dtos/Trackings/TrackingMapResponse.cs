namespace Postex.Product.Application.Dtos.Trackings
{
    public class TrackingMapResponse
    {
        public long CourierStatusMappingId { get; set; }
        public string TrackCode { get; set; }
        public string TrackStatus { get; set; }
        public string CourierStatus { get; set; }
        public string Date { get; set; }
    }
}
