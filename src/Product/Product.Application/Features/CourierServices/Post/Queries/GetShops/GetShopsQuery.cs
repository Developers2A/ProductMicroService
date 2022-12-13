using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.GetShops
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
