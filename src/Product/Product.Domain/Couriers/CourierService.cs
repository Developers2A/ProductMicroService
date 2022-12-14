using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierService : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
        public ICollection<CourierServiceZone> CourierServiceZones { get; set; }
    }
}
