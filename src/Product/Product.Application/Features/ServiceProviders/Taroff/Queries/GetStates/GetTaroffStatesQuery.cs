using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.ServiceProviders.Taroff.Queries.GetStates
{
    public class GetTaroffStatesQuery : ITransactionRequest<BaseResponse<List<TaroffState>>>
    {
        public string Token { get; set; }
    }
}
