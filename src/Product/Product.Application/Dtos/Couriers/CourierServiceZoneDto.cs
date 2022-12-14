namespace Product.Application.Dtos.Couriers
{
    public class CourierServiceZoneDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int? CourierServiceId { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
    }
}
