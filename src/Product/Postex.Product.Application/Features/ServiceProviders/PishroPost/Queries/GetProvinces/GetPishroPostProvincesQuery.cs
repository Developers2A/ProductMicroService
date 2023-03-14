using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.GetProvinces
{
    public class GetPishroPostProvincesQuery : ITransactionRequest<BaseResponse<List<ChaparState>>>
    {
    }
}
