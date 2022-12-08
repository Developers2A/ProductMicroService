namespace ProductService.Application.Dtos.Couriers
{
    public class CourierInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourierId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
