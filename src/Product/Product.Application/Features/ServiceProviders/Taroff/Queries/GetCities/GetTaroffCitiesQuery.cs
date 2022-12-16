using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.ServiceProviders.Taroff.Queries.GetCities
{
    public class GetTaroffCitiesQuery : ITransactionRequest<BaseResponse<List<TaroffState>>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("provinceid")]
        public int ProvinceId { get; set; }
    }
}
