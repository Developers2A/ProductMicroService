using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.EcoPeyk;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetPrice
{
    public class GetEcoPeykPriceQuery : ITransactionRequest<BaseResponse<List<EcoPeykGetPriceResponse>>>
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("orders")]
        public List<EcoPeykPriceOrder> Orders { get; set; }
    }

    public class EcoPeykPriceOrder
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }

        [JsonProperty("senderLocation")]
        public string SenderLocation { get; set; }

        [JsonProperty("senderPostalCode")]
        public string? SenderPostalCode { get; set; }

        [JsonProperty("receiverAddress")]
        public string ReceiverAddress { get; set; }

        [JsonProperty("receiverLocation")]
        public string ReceiverLocation { get; set; }

        [JsonProperty("receiverPostalCode")]
        public string? ReceiverPostalCode { get; set; }

        [JsonProperty("boxSize")]
        public int BoxSize { get; set; }

        [JsonProperty("boxPriceValue")]
        public int? BoxPriceValue { get; set; }

        [JsonProperty("cashOnDelivery")]
        public bool CashOnDelivery { get; set; }
    }
}
