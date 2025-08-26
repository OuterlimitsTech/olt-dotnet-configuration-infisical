using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;


/// <summary>
/// For Requests that require a secretPath
/// </summary>
public abstract class InfisicalBaseSecretPathRequest : InfisicalBaseSecretRequest
{
    /// <summary>
    /// default: /
    /// </summary>
    [JsonPropertyName("secretPath")]
    public required string SecretPath { get; init; } = LibConstants.RootPath;
}

