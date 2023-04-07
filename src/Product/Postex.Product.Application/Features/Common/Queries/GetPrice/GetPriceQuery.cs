using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons.GetPrice.Request;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Common.Queries.GetPrice
{
    public class GetPriceQuery : ITransactionRequest<BaseResponse<GetPriceResponse>>
    {
        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }

        [JsonPropertyName("post_ecommerce_shopid")]
        public string PostEcommerceShopID { get; set; }

        public CourierInfoDto Courier { get; set; }

        public SenderReceiverInfoDto Sender { get; set; }

        public SenderReceiverInfoDto Receiver { get; set; }

        public ParcelInfoDto Parcel { get; set; }

        public bool HasCollection { get; set; }

        public bool HasDistribution { get; set; }

        public List<int> ValueAddedTypeIds { get; set; }
    }
}
