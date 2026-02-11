using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

/// <summary>
/// For Requests that require a secretKey
/// </summary>
public abstract class InfisicalBaseSecretKeyRequest : InfisicalBaseSecretTypeRequest
{
    [JsonPropertyName("secretKey")]
    public required string SecretKey { get; init; }

}

