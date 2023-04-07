using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        [JsonIgnore]
        public Guid UserID { get; set; }

        [JsonPropertyName("post_ecommerce_userid")]
        public string PostEcommerceUserID { get; set; }

        [JsonPropertyName("courier_code")]
        public int CourierCode { get; set; }

        [JsonPropertyName("parcel_code")]
        public string ParcelCode { get; set; }

        [JsonPropertyName("sender_mobile")]
        public string SenderMobile { get; set; }

        public int Weight { get; set; }

        [JsonPropertyName("parcel_value")]
        public long ParcelValue { get; set; }

        [JsonPropertyName("non_standard")]
        public bool NonStandardPackage { get; set; }
    }
}
