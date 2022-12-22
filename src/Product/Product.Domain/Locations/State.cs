using Postex.SharedKernel.Domain;

namespace Product.Domain.Locations
{
    public class State : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? EnglishName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
