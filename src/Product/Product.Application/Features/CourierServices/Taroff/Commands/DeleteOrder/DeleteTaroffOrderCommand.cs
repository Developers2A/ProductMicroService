using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Taroff.Dtos;

namespace Product.Application.Features.CourierServices.Taroff.Commands.DeleteOrder
{
    public class DeleteTaroffOrderCommand : ITransactionRequest<BaseResponse<TaroffDeleteResponse>>
    {
        public string Token { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }
    }
}
