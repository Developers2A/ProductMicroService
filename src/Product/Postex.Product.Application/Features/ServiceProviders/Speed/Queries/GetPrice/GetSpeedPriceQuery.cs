using Newtonsoft.Json;
using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Speed;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Speed.Queries.GetPrice
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
