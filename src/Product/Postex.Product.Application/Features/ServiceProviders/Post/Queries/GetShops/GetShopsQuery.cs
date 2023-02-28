using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetShops
{
    public class GetShopsQuery : ITransactionRequest<BaseResponse<PostGetShopsResponse>>
    {
        public int PostUnitID { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public int PostnodeID { get; set; }
        public int PricePlanID { get; set; }
        public bool Enabled { get; set; }
        public DateTime FromContractEndDate { get; set; }
        public DateTime ToContractEndDate { get; set; }
        public string? Name { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
