using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class CourierInsurance : BaseEntity<int>
    {
        public string Name { get; set; }
        public int CourierId { get; set; }
        public CourierService Courier { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
