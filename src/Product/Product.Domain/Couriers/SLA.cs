using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class SLA : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
        public ICollection<CourierZoneSLA> CourierZoneSLAs { get; set; }
    }
}
