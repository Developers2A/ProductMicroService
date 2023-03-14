using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetProvinces
{
    public class GetChaparProvincesQuery : ITransactionRequest<BaseResponse<List<ChaparState>>>
    {
    }
}
