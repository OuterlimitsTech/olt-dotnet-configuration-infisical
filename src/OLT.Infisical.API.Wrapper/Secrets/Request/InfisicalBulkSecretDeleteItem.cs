using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalBulkSecretDeleteItem 
{
    [JsonPropertyName("secretKey")]
    public required string SecretKey { get; init; }

    /// <summary>
    /// shared or personal
    /// </summary>
    /// <remarks>
    /// default: shared
    /// </remarks>
    [JsonPropertyName("type")]
    public string Type { get; init; } = "shared";
}

