using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Request;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Commands.EditWeight
{
    public class EditWeightCommand : ITransactionRequest<BaseResponse<ParcelResponseDto>>
    {
        [JsonIgnore]
        public Guid UserID { get; set; }

        [JsonPropertyName("post_ecommerce_shopid")]
        public string PostEcommerceShopId { get; set; }

        [JsonPropertyName("courier")]
        public CourierDto Courier { get; set; }

        [JsonPropertyName("parcel_code")]
        public string ParcelCode { get; set; }

        public int Weight { get; set; }

        [JsonPropertyName("parcel_value")]
        public int ParcelValue { get; set; }

        [JsonPropertyName("non_standard")]
        public bool NonStandardPackage { get; set; }
    }
}
