using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.PishroPost.Queries.GetCities
{
    public class GetPishroPostCitiesQuery : ITransactionRequest<BaseResponse<List<ChaparCity>>>
    {
        public ChaparGetState State { get; set; }
    }

    public class ChaparGetState
    {
        public int No { get; set; }
    }
}
