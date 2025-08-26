using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets;

public sealed class InfisicalJwtToken
{
    [JsonPropertyName("identityId")]
    public string? IdentityId { get; init; }

    [JsonPropertyName("clientSecretId")]
    public string? ClientSecretId { get; init; }

    [JsonPropertyName("identityAccessTokenId")]
    public string? IdentityAccessTokenId { get; init; }

    [JsonPropertyName("authTokenType")]
    public string? AuthTokenType { get; init; }

    [JsonPropertyName("exp")]
    public long Exp { get; init; }
   
}