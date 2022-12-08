using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.GetUnits
{
    public class GetPostUnitsQuery : ITransactionRequest<BaseResponse<List<PostGetUnitsResponse>>>
    {
        public int ProvinceId { get; set; }
    }
}
