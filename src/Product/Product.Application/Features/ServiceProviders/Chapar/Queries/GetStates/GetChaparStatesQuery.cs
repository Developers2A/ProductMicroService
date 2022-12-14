using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Chapar;

namespace Product.Application.Features.ServiceProviders.Chapar.Queries.GetStates
{
    public class GetChaparStatesQuery : ITransactionRequest<BaseResponse<List<ChaparState>>>
    {
    }
}
