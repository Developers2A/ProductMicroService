using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons.EditParcel.Request;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.EditParcel
{
    public class EditParcelCommand : ITransactionRequest<BaseResponse<EditParcelResponse>>
    {
        [JsonPropertyName("post_ecommerce_shopid")]
        public string PostEcommerceShopId { get; set; }

        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }
        public ParcelEditDto Parcel { get; set; }

        public ReceiverEditDto To { get; set; }

        [JsonIgnore]
        public Guid UserID { get; set; }
    }
}
