using Postex.SharedKernel.Domain;

namespace Product.Domain.Locations
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
