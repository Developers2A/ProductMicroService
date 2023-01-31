using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Chapar;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Chapar.Queries.GetCities
{
    public class GetChaparCitiesQuery : ITransactionRequest<BaseResponse<List<ChaparCity>>>
    {
        public ChaparGetState State { get; set; }
    }

    public class ChaparGetState
    {
        public int No { get; set; }
    }
}
