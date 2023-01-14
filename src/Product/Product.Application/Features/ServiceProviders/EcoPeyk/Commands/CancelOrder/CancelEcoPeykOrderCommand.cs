using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.EcoPeyk;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CancelOrder
{
    public class CancelEcoPeykOrderCommand : ITransactionRequest<BaseResponse<EcoPeykCancelOrderResponse>>
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
