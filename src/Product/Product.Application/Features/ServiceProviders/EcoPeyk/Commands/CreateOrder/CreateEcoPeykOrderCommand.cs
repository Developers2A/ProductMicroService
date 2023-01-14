using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.EcoPeyk;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Commands.CreateOrder
{
    public class CreateEcoPeykOrderCommand : ITransactionRequest<BaseResponse<EcoPeykCreateOrderResponse>>
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("orders")]
        public List<EcoPeykOrder> Orders { get; set; }
    }

    public class EcoPeykOrder
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("senderTitle")]
        public string SenderTitle { get; set; }

        [JsonProperty("senderPhone")]
        public string SenderPhone { get; set; }

        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }

        [JsonProperty("senderLocation")]
        public string SenderLocation { get; set; }

        [JsonProperty("senderPostalCode")]
        public string? SenderPostalCode { get; set; }

        [JsonProperty("senderComment")]
        public string SenderComment { get; set; }

        [JsonProperty("pickupDate")]
        public string PickupDate { get; set; }

        [JsonProperty("pickupShift")]
        public int PickupShift { get; set; }

        [JsonProperty("receiverTitle")]
        public string ReceiverTitle { get; set; }

        [JsonProperty("receiverPhone")]
        public string ReceiverPhone { get; set; }

        [JsonProperty("receiverAddress")]
        public string ReceiverAddress { get; set; }

        [JsonProperty("receiverLocation")]
        public string ReceiverLocation { get; set; }

        [JsonProperty("receiverComment")]
        public string ReceiverComment { get; set; }

        [JsonProperty("deliveryDate")]
        public string DeliveryDate { get; set; }

        [JsonProperty("deliveryShift")]
        public int DeliveryShift { get; set; }

        [JsonProperty("boxSize")]
        public int BoxSize { get; set; }

        [JsonProperty("boxPriceValue")]
        public int? BoxPriceValue { get; set; }

        [JsonProperty("cashOnDelivery")]
        public bool CashOnDelivery { get; set; }
    }
}
