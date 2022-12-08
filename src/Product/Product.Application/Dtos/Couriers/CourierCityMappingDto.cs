namespace ProductService.Application.Dtos.Couriers
{
    public class CourierCityMappingDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int CityId { get; set; }
        public int Code { get; set; }
        public string MappedCode { get; set; }
    }
}
