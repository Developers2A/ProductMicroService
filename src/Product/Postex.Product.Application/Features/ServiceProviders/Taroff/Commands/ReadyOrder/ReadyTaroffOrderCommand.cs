using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Taroff.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Taroff.Commands.ReadyOrder
{
    public class ReadyTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffReadyOrderResponse>>
    {
        public string Token { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }
    }
}
