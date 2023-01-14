using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Kbk.Dtos;

namespace Product.Application.Features.ServiceProviders.Kbk.Commands.CancelOrder
{
    public class CancelKbkOrderCommand : ITransactionRequest<BaseResponse<KbkCancelResponse>>
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        [JsonProperty("shipmentCode")]
        public string ShipmentCode { get; set; }
    }
}
