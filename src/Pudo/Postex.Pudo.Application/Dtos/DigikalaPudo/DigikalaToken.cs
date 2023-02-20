using Newtonsoft.Json;

namespace Postex.Pudo.Application.Dtos.DigikalaPudo;

public class DigikalaToken
{
    [JsonProperty("accessToken")]
    public string AccessToken { get; set; }

    [JsonProperty("tokenType")]
    public string TokenType { get; set; }

    [JsonProperty("expiresIn")]
    public int ExpiresIn { get; set; }

    [JsonProperty("refreshToken")]
    public string RefreshToken { get; set; }
}
