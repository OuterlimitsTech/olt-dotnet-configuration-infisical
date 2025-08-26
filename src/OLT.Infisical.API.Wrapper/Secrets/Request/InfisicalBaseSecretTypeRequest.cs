using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;


/// <summary>
/// For Requests that require a secretPath and type
/// </summary>
public abstract class InfisicalBaseSecretTypeRequest : InfisicalBaseSecretPathRequest
{
    /// <summary>
    /// shared or personal
    /// </summary>
    /// <remarks>
    /// default: shared
    /// </remarks>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "shared";
}

