using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Posts
{
    public class PostCityShop : BaseEntity<int>
    {
        public int ShopId { get; set; }
        public string Code { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public int CityCode { get; set; }
    }
}
