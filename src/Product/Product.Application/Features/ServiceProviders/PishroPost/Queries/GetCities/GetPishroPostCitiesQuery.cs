using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Chapar;

namespace Product.Application.Features.ServiceProviders.PishroPost.Queries.GetCities
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
