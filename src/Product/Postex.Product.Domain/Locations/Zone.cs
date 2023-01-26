using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Locations
{
    public class Zone : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
