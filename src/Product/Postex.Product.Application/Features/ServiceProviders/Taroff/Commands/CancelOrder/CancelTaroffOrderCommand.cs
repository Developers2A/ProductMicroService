using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffCancelResponse>>
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("orderid")]
        public int OrderId { get; set; }
    }
}
