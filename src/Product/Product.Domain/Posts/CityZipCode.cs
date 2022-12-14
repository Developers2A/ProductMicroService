using Postex.SharedKernel.Domain;
using Product.Domain.Locations;

namespace ServiceProvider.Domain.Couriers
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
