using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.CourierServices.Taroff.Queries.GetCities
{
    public class GetTaroffCitiesQuery : ITransactionRequest<BaseResponse<List<TaroffState>>>
    {
        public string Token { get; set; }
        public int ProvinceId { get; set; }
    }
}
