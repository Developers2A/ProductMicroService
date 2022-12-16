using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class Status : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Code { get; set; }
        public string? Type { get; set; }
        public ICollection<CourierStatusMapping> CourierStatusMappings { get; set; }
    }
}
