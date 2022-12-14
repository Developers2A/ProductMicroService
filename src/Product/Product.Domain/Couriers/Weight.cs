using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class Weight : BaseEntity<int>
    {
        public int PostageWeight { get; set; }
        public string Code { get; set; }
        public ICollection<CourierServiceZonePrice> CourierServiceZonePrices { get; set; }
    }
}
