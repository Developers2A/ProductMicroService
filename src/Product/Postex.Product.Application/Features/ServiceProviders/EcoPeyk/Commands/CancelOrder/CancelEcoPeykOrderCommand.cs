using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.EcoPeyk;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CancelOrder
{
    public class CancelEcoPeykOrderCommand : ITransactionRequest<BaseResponse<EcoPeykCancelOrderResponse>>
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
