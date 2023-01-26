using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.GetStates
{
    public class GetChaparStatesQuery : ITransactionRequest<BaseResponse<List<ChaparState>>>
    {
    }
}
