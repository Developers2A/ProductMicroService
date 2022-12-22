using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Speed.Dtos;

namespace Product.Application.Features.ServiceProviders.Speed.Commands.CancelOrder
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
