namespace ProductService.Application.Dtos.Couriers
{
    public class CourierStatusMappingDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StatusId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
