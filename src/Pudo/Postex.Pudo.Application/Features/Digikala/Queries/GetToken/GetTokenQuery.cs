using Newtonsoft.Json;
using Postex.Pudo.Application.Contracts;
using Postex.Pudo.Application.Dtos.DigikalaPudo;
using Postex.SharedKernel.Common;

namespace Postex.Pudo.Application.Features.Digikala.Queries.GetToken;

public class GetTokenQuery : ITransactionRequest<BaseResponse<DigikalaToken>>
{
    [JsonProperty("grantType")]
    public string GrantType { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
}
