namespace ProductService.Application.Dtos.Couriers
{
    public class CourierZoneSLADto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int? SLAId { get; set; }
        public int StateFromId { get; set; }
        public int StateToId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
    }
}
