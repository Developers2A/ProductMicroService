using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetStatus
{
    public class GetPostStatusQuery : ITransactionRequest<BaseResponse<List<PostOrderStatusResponse>>>
    {
        public List<string> ParcelCodes { get; set; }
    }
}
