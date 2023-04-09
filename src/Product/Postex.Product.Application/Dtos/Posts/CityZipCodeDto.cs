namespace Postex.Product.Application.Dtos.Posts
{
    public class CityZipCodeDto
    {
        public int? CityId { get; set; }
        public string ZipCode { get; set; }
        public bool IsValid { get; set; }
    }
}
