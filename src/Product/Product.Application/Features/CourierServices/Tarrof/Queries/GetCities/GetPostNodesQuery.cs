using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.Post;

namespace Product.Application.Features.CourierServices.Tarrof.Queries.GetCities
{
    public class GetPostNodesQuery : ITransactionRequest<BaseResponse<List<PostGetNodesResponse>>>
    {
        public int CityId { get; set; }
    }
}
