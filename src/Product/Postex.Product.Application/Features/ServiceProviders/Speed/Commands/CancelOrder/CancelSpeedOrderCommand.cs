using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Speed.Dtos;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder
{
    public class CancelSpeedOrderCommand : ITransactionRequest<BaseResponse<SpeedCancelOrderResponse>>
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("barcode")]
        public long Barcode { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
