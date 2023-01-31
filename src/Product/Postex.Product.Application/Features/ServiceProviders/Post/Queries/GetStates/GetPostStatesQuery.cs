using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Post;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Post.Queries.GetStates
{
    public class GetPostStatesQuery : ITransactionRequest<BaseResponse<List<PostGetStatesResponse>>>
    {
    }
}
