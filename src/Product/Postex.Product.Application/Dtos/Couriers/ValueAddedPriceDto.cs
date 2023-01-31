using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Dtos.Couriers
{
    public class ValueAddedPriceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public ValueAddedType ValueAddedType { get; set; }
    }
}
