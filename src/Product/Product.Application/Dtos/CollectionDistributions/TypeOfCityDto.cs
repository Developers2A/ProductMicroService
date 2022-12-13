namespace Product.Application.Dtos.CollectionDistributions
{
    public class TypeOfCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityType { get; set; }
        public decimal EntryPrice { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
