namespace Postex.Product.Application.Dtos.Couriers
{
    public class CourierCityMappingDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public CourierDto Courier { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
