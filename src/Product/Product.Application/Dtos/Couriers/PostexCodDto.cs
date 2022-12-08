namespace ProductService.Application.Dtos.Couriers
{
    public class PostexCodDto
    {
        public string Name { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
