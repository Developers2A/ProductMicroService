using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Request;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponseDto>>
    {
        [JsonProperty("from")]
        public SenderReceiverDto From { get; set; }

        [JsonProperty("to")]
        public SenderReceiverDto To { get; set; }

        [JsonProperty("parcel_properties")]
        public ParcelDto Parcel { get; set; }

        [JsonProperty("courier")]
        public CourierDto Courier { get; set; }

        [JsonProperty("value_added_service")]
        public List<int>? ValueAddedTypeIds { get; set; }

        [JsonProperty("request_pickup")]
        public DeliveryPickupDto Pickup { get; set; }

        [JsonProperty("request_delivery")]
        public DeliveryPickupDto Delivery { get; set; }
    }
}
