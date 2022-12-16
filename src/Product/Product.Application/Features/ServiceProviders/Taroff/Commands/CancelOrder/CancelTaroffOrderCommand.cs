using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffCancelResponse>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("orderid")]
        public int OrderId { get; set; }
    }
}
