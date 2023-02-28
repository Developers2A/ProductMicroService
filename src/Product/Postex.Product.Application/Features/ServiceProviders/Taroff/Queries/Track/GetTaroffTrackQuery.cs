using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Queries.Track
{
    public class GetTaroffTrackQuery : ITransactionRequest<BaseResponse<TaroffTrackResponse>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("orderid")]
        public int OrderId { get; set; }
    }
}
