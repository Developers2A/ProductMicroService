using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Posts
{
    public class CityZipCode : BaseEntity<int>
    {
        public int? CityId { get; set; }
        public City City { get; set; }
        public string ZipCode { get; set; }
        public string? ParcelCode { get; set; }
        public bool IsValid { get; set; }
    }
}
