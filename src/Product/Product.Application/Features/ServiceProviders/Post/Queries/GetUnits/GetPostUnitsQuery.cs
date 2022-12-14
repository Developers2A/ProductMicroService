using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Queries.GetUnits
{
    public class GetPostUnitsQuery : ITransactionRequest<BaseResponse<List<PostGetUnitsResponse>>>
    {
        public int ProvinceId { get; set; }
    }
}
