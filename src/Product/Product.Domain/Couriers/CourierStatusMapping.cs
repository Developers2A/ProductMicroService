using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierStatusMapping : BaseEntity<int>
    {
        public int CourierApiId { get; set; }
        public CourierApi CourierApi { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
