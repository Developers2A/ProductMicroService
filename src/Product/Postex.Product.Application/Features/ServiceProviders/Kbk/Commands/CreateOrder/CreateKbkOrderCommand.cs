using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Kbk.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Kbk.Commands.CreateOrder
{
    public class CreateKbkOrderCommand : ITransactionRequest<BaseResponse<KbkCreateOrderResponse>>
    {
        [JsonProperty("apiCode")]
        public string ApiCode { get; set; }

        [JsonProperty("postexShipmentCode")]
        public string PostexShipmentCode { get; set; }

        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        [JsonProperty("senderPhone")]
        public string SenderPhone { get; set; }

        [JsonProperty("senderAddr")]
        public string SenderAddr { get; set; }

        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }

        [JsonProperty("receiverPhone")]
        public string ReceiverPhone { get; set; }

        [JsonProperty("receiverAddr")]
        public string ReceiverAddr { get; set; }

        [JsonProperty("originCity")]
        public int OriginCity { get; set; }

        [JsonProperty("destinationCity")]
        public int DestinationCity { get; set; }

        [JsonProperty("packetsDetail")]
        public List<PacketsDetail> Detail { get; set; }
    }

    public class PacketsDetail
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }
    }
}
