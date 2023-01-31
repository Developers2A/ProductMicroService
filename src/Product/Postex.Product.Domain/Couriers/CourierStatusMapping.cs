using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class CourierStatusMapping : BaseEntity<int>
    {
        public int Version { get; set; }
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
