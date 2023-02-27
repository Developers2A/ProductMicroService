namespace Postex.Product.Application.Dtos.Contratcs
{
    public class CourierServicePriceDto
    {
        public int CourierServiceId { get; set; }
        public int ContractId { get; set; }
        public int ContractCourierId { get; set; }
        public double DefaultFixedDiscount { get; set; }
        public double DefaultPercentDiscount { get; set; }
        public double ContractFixedDiscount { get; set; }
        public double ContractPercentDiscount { get; set; }
        public string ContractLevel { get; set; }
    }
}
