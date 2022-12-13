namespace Product.Application.Dtos.Couriers
{
    public class PostexInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
