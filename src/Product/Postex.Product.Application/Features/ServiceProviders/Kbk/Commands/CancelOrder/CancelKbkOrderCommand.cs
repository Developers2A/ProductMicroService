using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder
{
    public class CancelKbkOrderCommand : ITransactionRequest<BaseResponse<KbkCancelResponse>>
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        [JsonProperty("shipmentCode")]
        public string ShipmentCode { get; set; }
    }
}
