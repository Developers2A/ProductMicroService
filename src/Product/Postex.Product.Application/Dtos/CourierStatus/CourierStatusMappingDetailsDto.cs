namespace Postex.Product.Application.Dtos.CourierStatus
{
    public class CourierStatusMappingDetailsDto
    {
        public int Id { get; set; }
        public int CourierCode { get; set; }
        public string CourierName { get; set; }
        public string CourierStatusCode { get; set; }
        public string CourierStatusTitle { get; set; }
        public string CourierStatusDescription { get; set; }
        public string PostexStatusCode { get; set; }
        public string PostexStatusTitle { get; set; }
        public string PostexStatusDescription { get; set; }
    }
}
