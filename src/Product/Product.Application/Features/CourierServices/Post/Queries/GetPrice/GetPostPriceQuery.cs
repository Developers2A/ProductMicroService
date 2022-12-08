using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Post.Queries.GetPrice
{
    public class GetPostPriceQuery : ITransactionRequest<BaseResponse<PostGetPriceResponse>>
    {
    }
}
