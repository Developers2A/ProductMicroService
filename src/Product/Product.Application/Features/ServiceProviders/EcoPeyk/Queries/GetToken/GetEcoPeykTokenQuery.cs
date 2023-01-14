using Newtonsoft.Json;
using Product.Application.Contracts;

namespace Product.Application.Features.ServiceProviders.EcoPeyk.Queries.GetToken
{
    public class GetEcoPeykTokenQuery : ITransactionRequest<string>
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
