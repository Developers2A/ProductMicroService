using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Request;
using Postex.Product.Application.Dtos.Commons.CreateOrder.Response;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateParcelCommand : ITransactionRequest<BaseResponse<CreateParcelResponseDto>>
    {
        [JsonIgnore]
        public Guid UserID { get; set; }

        [JsonPropertyName("post_ecommerce_shopid")]
        public string PostEcommerceShopId { get; set; }

        [JsonPropertyName("from")]
        public SenderReceiverDto From { get; set; }

        [JsonPropertyName("to")]
        public SenderReceiverDto To { get; set; }

        [JsonPropertyName("parcel_properties")]
        public ParcelDto Parcel { get; set; }

        [JsonPropertyName("courier")]
        public CourierDto Courier { get; set; }

        [JsonPropertyName("value_added_service")]
        public List<int> ValueAddedTypeIds { get; set; }

        [JsonPropertyName("request_pickup")]
        public DeliveryPickupDto Pickup { get; set; }

        [JsonPropertyName("request_delivery")]
        public DeliveryPickupDto Delivery { get; set; }
    }
}
