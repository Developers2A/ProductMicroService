using Newtonsoft.Json;
using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Speed.Dtos;

namespace Product.Application.Features.ServiceProviders.Speed.Queries.GetPrice
{
    public class GetSpeedPriceQuery : ITransactionRequest<BaseResponse<SpeedGetPriceResponse>>
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("vol")]
        public int Vol { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
