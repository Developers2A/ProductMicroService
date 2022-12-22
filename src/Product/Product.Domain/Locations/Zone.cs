using Postex.SharedKernel.Domain;

namespace Product.Domain.Locations
{
    public class Zone : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
