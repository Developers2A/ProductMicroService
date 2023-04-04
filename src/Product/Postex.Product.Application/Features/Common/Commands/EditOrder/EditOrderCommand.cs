using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons.EditOrder.Request;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }
        public ParcelEditDto Parcel { get; set; }

        [JsonPropertyName("sender_mobile")]
        public string SenderMobile { get; set; }
        public ReceiverEditDto To { get; set; }
    }
}
