using Postex.SharedKernel.Domain;

namespace Product.Domain.Locations
{
    public class City : BaseEntity<int>
    {
        public int StateId { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
    }
}
