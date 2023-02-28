using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetUnits
{
    public class GetPostUnitsQuery : ITransactionRequest<BaseResponse<List<PostGetUnitsResponse>>>
    {
        public int ProvinceId { get; set; }
    }
}
