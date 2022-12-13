using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.CourierServices.Taroff.Commands.CancelOrder
{
    public class CancelTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffCancelResponse>>
    {
        public string Token { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }
    }
}
