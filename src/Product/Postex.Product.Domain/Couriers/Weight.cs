using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class Weight : BaseEntity<int>
    {
        public int PostageWeight { get; set; }
        public string Code { get; set; }
    }
}
