namespace Postex.Product.Application.Dtos.Commons
{
    public class CityDto
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string? EnglishName { get; set; }
    }
}
