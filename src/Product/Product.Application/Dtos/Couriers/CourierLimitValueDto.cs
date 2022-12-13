namespace Product.Application.Dtos.Couriers
{
    public class CourierLimitValueDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int CourierLimitId { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
        public int? CityId { get; set; }
        public int FromOrToType { get; set; }
    }
}
