using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Post;

namespace Product.Application.Features.ServiceProviders.Post.Queries.GetStates
{
    public class GetPostStatesQuery : ITransactionRequest<BaseResponse<List<PostGetStatesResponse>>>
    {
    }
}
