using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Locations
{
    public class Province : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public string? EnglishName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
