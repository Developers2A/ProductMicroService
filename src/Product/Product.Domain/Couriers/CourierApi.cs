using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierApi : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public ICollection<CourierStatusMapping> CourierStatusMappings { get; set; }
    }
}
