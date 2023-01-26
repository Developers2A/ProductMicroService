namespace Postex.Product.Application.Dtos.Trackings
{
    public class TrackingMapResponse
    {
        public long CourierStatusMappingId { get; set; }
        public string TrackingCode { get; set; }
        public string TrackingStatusNote { get; set; }
        public string CourierStatus { get; set; }
        public string Date { get; set; }
    }
}
